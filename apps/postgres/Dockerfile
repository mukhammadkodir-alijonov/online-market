FROM postgres:14.1-alpine
ENV POSTGRES_USER=postgresuser
ENV POSTGRES_PASSWORD=23f2760f-1134-40b1-bbe0-da3a348ffda7
COPY /apps/postgres/init.sql /docker-entrypoint-initdb.d/create_tables.sql
