"use strict";

// Class definition
var KTBlockUI = function (element, options) {
    //////////////////////////////
    // ** Private variables  ** //
    //////////////////////////////
    var the = this;

    if (typeof element === "undefined" || element === null) {
        return;
    }

    // Default options
    var defaultOptions = {
        zIndex: false,
        overlayClass: '',
        overflow: 'hidden',
        message: '<span class="spinner-border text-primary"></span>'
    };

    ////////////////////////////
    // ** Private methods  ** //
    ////////////////////////////

    var _construct = function () {
        if (KTUtil.data(element).has('blockui')) {
            the = KTUtil.data(element).get('blockui');
        } else {
            _init();
        }
    }

    var _init = function () {
        // Variables
        the.options = KTUtil.deepExtend({}, defaultOptions, options);
        the.element = element;
        the.overlayElement = null;
        the.blocked = false;
        the.positionChanged = false;
        the.overflowChanged = false;

        // Bind Instance
        KTUtil.data(the.element).set('blockui', the);
    }

    var _block = function () {
        if (KTEventHandler.trigger(the.element, 'kt.blockui.block', the) === false) {
            return;
        }

        var isPage = (the.element.tagName === 'BODY');

        var position = KTUtil.css(the.element, 'position');
        var overflow = KTUtil.css(the.element, 'overflow');
        var zIndex = isPage ? 10000 : 1;

        if (the.options.zIndex > 0) {
            zIndex = the.options.zIndex;
        } else {
            if (KTUtil.css(the.element, 'z-index') != 'auto') {
                zIndex = KTUtil.css(the.element, 'z-index');
            }
        }

        the.element.classList.add('blockui');

        if (position === "absolute" || position === "relative" || position === "fixed") {
            KTUtil.css(the.element, 'position', 'relative');
            the.positionChanged = true;
        }

        if (the.options.overflow === 'hidden' && overflow === 'visible') {
            KTUtil.css(the.element, 'overflow', 'hidden');
            the.overflowChanged = true;
        }

        the.overlayElement = document.createElement('DIV');
        the.overlayElement.setAttribute('class', 'blockui-overlay ' + the.options.overlayClass);

        the.overlayElement.innerHTML = the.options.message;

        KTUtil.css(the.overlayElement, 'z-index', zIndex);

        the.element.append(the.overlayElement);
        the.blocked = true;

        KTEventHandler.trigger(the.element, 'kt.blockui.after.blocked', the) === false
    }

    var _release = function () {
        if (KTEventHandler.trigger(the.element, 'kt.blockui.release', the) === false) {
            return;
        }

        the.element.classList.add('blockui');

        if (the.positionChanged) {
            KTUtil.css(the.element, 'position', '');
        }

        if (the.overflowChanged) {
            KTUtil.css(the.element, 'overflow', '');
        }

        if (the.overlayElement) {
            KTUtil.remove(the.overlayElement);
        }

        the.blocked = false;

        KTEventHandler.trigger(the.element, 'kt.blockui.released', the);
    }

    var _isBlocked = function () {
        return the.blocked;
    }

    var _destroy = function () {
        KTUtil.data(the.element).remove('blockui');
    }

    // Construct class
    _construct();

    ///////////////////////
    // ** Public API  ** //
    ///////////////////////

    // Plugin API
    the.block = function () {
        _block();
    }

    the.release = function () {
        _release();
    }

    the.isBlocked = function () {
        return _isBlocked();
    }

    the.destroy = function () {
        return _destroy();
    }

    // Event API
    the.on = function (name, handler) {
        return KTEventHandler.on(the.element, name, handler);
    }

    the.one = function (name, handler) {
        return KTEventHandler.one(the.element, name, handler);
    }

    the.off = function (name) {
        return KTEventHandler.off(the.element, name);
    }

    the.trigger = function (name, event) {
        return KTEventHandler.trigger(the.element, name, event, the, event);
    }
};

// Static methods
KTBlockUI.getInstance = function (element) {
    if (element !== null && KTUtil.data(element).has('blockui')) {
        return KTUtil.data(element).get('blockui');
    } else {
        return null;
    }
}

// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
    module.exports = KTBlockUI;
}
"use strict";
// DOCS: https://javascript.info/cookie

// Class definition
var KTCookie = function () {
    return {
        // returns the cookie with the given name,
        // or undefined if not found
        get: function (name) {
            var matches = document.cookie.match(new RegExp(
                "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
            ));

            return matches ? decodeURIComponent(matches[1]) : null;
        },

        // Please note that a cookie value is encoded,
        // so getCookie uses a built-in decodeURIComponent function to decode it.
        set: function (name, value, options) {
            if (typeof options === "undefined" || options === null) {
                options = {};
            }

            options = Object.assign({}, {
                path: '/'
            }, options);

            if (options.expires instanceof Date) {
                options.expires = options.expires.toUTCString();
            }

            var updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);

            for (var optionKey in options) {
                if (options.hasOwnProperty(optionKey) === false) {
                    continue;
                }

                updatedCookie += "; " + optionKey;
                var optionValue = options[optionKey];

                if (optionValue !== true) {
                    updatedCookie += "=" + optionValue;
                }
            }

            document.cookie = updatedCookie;
        },

        // To remove a cookie, we can call it with a negative expiration date:
        remove: function (name) {
            this.set(name, "", {
                'max-age': -1
            });
        }
    }
}();

// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
    module.exports = KTCookie;
}

"use strict";

// Class definition
var KTDrawer = function (element, options) {
    //////////////////////////////
    // ** Private variables  ** //
    //////////////////////////////
    var the = this;
    var body = document.getElementsByTagName("BODY")[0];

    if (typeof element === "undefined" || element === null) {
        return;
    }

    // Default options
    var defaultOptions = {
        overlay: true,
        direction: 'end',
        baseClass: 'drawer',
        overlayClass: 'drawer-overlay'
    };

    ////////////////////////////
    // ** Private methods  ** //
    ////////////////////////////

    var _construct = function () {
        if (KTUtil.data(element).has('drawer')) {
            the = KTUtil.data(element).get('drawer');
        } else {
            _init();
        }
    }

    var _init = function () {
        // Variables
        the.options = KTUtil.deepExtend({}, defaultOptions, options);
        the.uid = KTUtil.getUniqueId('drawer');
        the.element = element;
        the.overlayElement = null;
        the.name = the.element.getAttribute('data-kt-drawer-name');
        the.shown = false;
        the.lastWidth;
        the.toggleElement = null;

        // Set initialized
        the.element.setAttribute('data-kt-drawer', 'true');

        // Event Handlers
        _handlers();

        // Update Instance
        _update();

        // Bind Instance
        KTUtil.data(the.element).set('drawer', the);
    }

    var _handlers = function () {
        var togglers = _getOption('toggle');
        var closers = _getOption('close');

        if (togglers !== null && togglers.length > 0) {
            KTUtil.on(body, togglers, 'click', function (e) {
                e.preventDefault();

                the.toggleElement = this;
                _toggle();
            });
        }

        if (closers !== null && closers.length > 0) {
            KTUtil.on(body, closers, 'click', function (e) {
                e.preventDefault();

                the.closeElement = this;
                _hide();
            });
        }
    }

    var _toggle = function () {
        if (KTEventHandler.trigger(the.element, 'kt.drawer.toggle', the) === false) {
            return;
        }

        if (the.shown === true) {
            _hide();
        } else {
            _show();
        }

        KTEventHandler.trigger(the.element, 'kt.drawer.toggled', the);
    }

    var _hide = function () {
        if (KTEventHandler.trigger(the.element, 'kt.drawer.hide', the) === false) {
            return;
        }

        the.shown = false;

        _deleteOverlay();

        body.removeAttribute('data-kt-drawer-' + the.name, 'on');
        body.removeAttribute('data-kt-drawer');

        KTUtil.removeClass(the.element, the.options.baseClass + '-on');

        if (the.toggleElement !== null) {
            KTUtil.removeClass(the.toggleElement, 'active');
        }

        KTEventHandler.trigger(the.element, 'kt.drawer.after.hidden', the) === false
    }

    var _show = function () {
        if (KTEventHandler.trigger(the.element, 'kt.drawer.show', the) === false) {
            return;
        }

        the.shown = true;

        _createOverlay();
        body.setAttribute('data-kt-drawer-' + the.name, 'on');
        body.setAttribute('data-kt-drawer', 'on');

        KTUtil.addClass(the.element, the.options.baseClass + '-on');

        if (the.toggleElement !== null) {
            KTUtil.addClass(the.toggleElement, 'active');
        }

        KTEventHandler.trigger(the.element, 'kt.drawer.shown', the);
    }

    var _update = function () {
        var width = _getWidth();
        var direction = _getOption('direction');

        // Reset state
        if (KTUtil.hasClass(the.element, the.options.baseClass + '-on') === true && String(body.getAttribute('data-kt-drawer-' + the.name + '-')) === 'on') {
            the.shown = true;
        } else {
            the.shown = false;
        }

        // Activate/deactivate
        if (_getOption('activate') === true) {
            KTUtil.addClass(the.element, the.options.baseClass);
            KTUtil.addClass(the.element, the.options.baseClass + '-' + direction);
            KTUtil.css(the.element, 'width', width, true);

            the.lastWidth = width;
        } else {
            KTUtil.css(the.element, 'width', '');

            KTUtil.removeClass(the.element, the.options.baseClass);
            KTUtil.removeClass(the.element, the.options.baseClass + '-' + direction);

            _hide();
        }
    }

    var _createOverlay = function () {
        if (_getOption('overlay') === true) {
            the.overlayElement = document.createElement('DIV');

            KTUtil.css(the.overlayElement, 'z-index', KTUtil.css(the.element, 'z-index') - 1); // update

            body.append(the.overlayElement);

            KTUtil.addClass(the.overlayElement, _getOption('overlay-class'));

            KTUtil.addEvent(the.overlayElement, 'click', function (e) {
                e.preventDefault();
                _hide();
            });
        }
    }

    var _deleteOverlay = function () {
        if (the.overlayElement !== null) {
            KTUtil.remove(the.overlayElement);
        }
    }

    var _getOption = function (name) {
        if (the.element.hasAttribute('data-kt-drawer-' + name) === true) {
            var attr = the.element.getAttribute('data-kt-drawer-' + name);
            var value = KTUtil.getResponsiveValue(attr);

            if (value !== null && String(value) === 'true') {
                value = true;
            } else if (value !== null && String(value) === 'false') {
                value = false;
            }

            return value;
        } else {
            var optionName = KTUtil.snakeToCamel(name);

            if (the.options[optionName]) {
                return KTUtil.getResponsiveValue(the.options[optionName]);
            } else {
                return null;
            }
        }
    }

    var _getWidth = function () {
        var width = _getOption('width');

        if (width === 'auto') {
            width = KTUtil.css(the.element, 'width');
        }

        return width;
    }

    var _destroy = function () {
        KTUtil.data(the.element).remove('drawer');
    }

    // Construct class
    _construct();

    ///////////////////////
    // ** Public API  ** //
    ///////////////////////

    // Plugin API
    the.toggle = function () {
        return _toggle();
    }

    the.show = function () {
        return _show();
    }

    the.hide = function () {
        return _hide();
    }

    the.isShown = function () {
        return the.shown;
    }

    the.update = function () {
        _update();
    }

    the.goElement = function () {
        return the.element;
    }

    the.destroy = function () {
        return _destroy();
    }

    // Event API
    the.on = function (name, handler) {
        return KTEventHandler.on(the.element, name, handler);
    }

    the.one = function (name, handler) {
        return KTEventHandler.one(the.element, name, handler);
    }

    the.off = function (name) {
        return KTEventHandler.off(the.element, name);
    }

    the.trigger = function (name, event) {
        return KTEventHandler.trigger(the.element, name, event, the, event);
    }
};

// Static methods
KTDrawer.getInstance = function (element) {
    if (element !== null && KTUtil.data(element).has('drawer')) {
        return KTUtil.data(element).get('drawer');
    } else {
        return null;
    }
}

// Hide all drawers and skip one if provided
KTDrawer.hideAll = function (skip = null, selector = '[data-kt-drawer="true"]') {
    var items = document.querySelectorAll(selector);

    if (items && items.length > 0) {
        for (var i = 0, len = items.length; i < len; i++) {
            var item = items[i];
            var drawer = KTDrawer.getInstance(item);

            if (!drawer) {
                continue;
            }

            if (skip) {
                if (item !== skip) {
                    drawer.hide();
                }
            } else {
                drawer.hide();
            }
        }
    }
}

// Update all drawers
KTDrawer.updateAll = function (selector = '[data-kt-drawer="true"]') {
    var items = document.querySelectorAll(selector);

    if (items && items.length > 0) {
        for (var i = 0, len = items.length; i < len; i++) {
            var item = items[i];
            var drawer = KTDrawer.getInstance(item);

            if (drawer) {
                drawer.update();;
            }
        }
    }
}

// Create instances
KTDrawer.createInstances = function (selector = '[data-kt-drawer="true"]') {
    var body = document.getElementsByTagName("BODY")[0];

    // Initialize Menus
    var elements = body.querySelectorAll(selector);
    var drawer;

    if (elements && elements.length > 0) {
        for (var i = 0, len = elements.length; i < len; i++) {
            drawer = new KTDrawer(elements[i]);
        }
    }
}

// Toggle instances
KTDrawer.handleShow = function () {
    // External drawer toggle handler
    KTUtil.on(document.body, '[data-kt-drawer-show="true"][data-kt-drawer-target]', 'click', function (e) {
        var element = document.querySelector(this.getAttribute('data-kt-drawer-target'));

        if (element) {
            KTDrawer.getInstance(element).show();
        }
    });
}

// Dismiss instances
KTDrawer.handleDismiss = function () {
    // External drawer toggle handler
    KTUtil.on(document.body, '[data-kt-drawer-dismiss="true"]', 'click', function (e) {
        var element = this.closest('[data-kt-drawer="true"]');

        if (element) {
            var drawer = KTDrawer.getInstance(element);
            if (drawer.isShown()) {
                drawer.hide();
            }
        }
    });
}

// Window resize Handling
window.addEventListener('resize', function () {
    var timer;
    var body = document.getElementsByTagName("BODY")[0];

    KTUtil.throttle(timer, function () {
        // Locate and update drawer instances on window resize
        var elements = body.querySelectorAll('[data-kt-drawer="true"]');

        if (elements && elements.length > 0) {
            for (var i = 0, len = elements.length; i < len; i++) {
                var drawer = KTDrawer.getInstance(elements[i]);
                if (drawer) {
                    drawer.update();
                }
            }
        }
    }, 200);
});

// Global initialization
KTDrawer.init = function () {
    KTDrawer.createInstances();
    KTDrawer.handleShow();
    KTDrawer.handleDismiss();
};

// On document ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', KTDrawer.init);
} else {
    KTDrawer.init();
}

// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
    module.exports = KTDrawer;
}
"use strict";
