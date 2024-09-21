#!/bin/sh

openssl genpkey -algorithm ed25519 -out jwt-private.pem
openssl pkey -in jwt-private.pem -pubout -out jwt-public.pem
openssl pkey -in jwt-private.pem -out jwt-private.der -outform DER
openssl pkey -in jwt-private.pem -pubout -out jwt-public.der -outform DER