# pull official base image
FROM node:13.12.0-alpine

WORKDIR /app

RUN apk add --no-cache git curl 
RUN npm i -g serve

COPY . .

RUN yarn 
RUN yarn build 
RUN rm -rf node_modules

EXPOSE 3000

CMD ["serve", "-p", "3000", "-s", "build"]
