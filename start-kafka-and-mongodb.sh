#!/bin/sh
KAFKA_PATH="/usr/local/Cellar/kafka/1.0.0/bin/"
KAFKA_CONFIG="/usr/local/Cellar/kafka/1.0.0/libexec/config/"
MONGODB_PATH="/usr/local/Cellar/mongodb/3.6.2/bin/"
${KAFKA_PATH}zookeeper-server-start ${KAFKA_CONFIG}zookeeper.properties &
${KAFKA_PATH}kafka-server-start ${KAFKA_CONFIG}server.properties &
${MONGODB_PATH}mongod &

