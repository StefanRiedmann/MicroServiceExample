SHORT DESCRIPTION

Small microservice example with 1 Frontend and 2 Microservices.

1. The frontend only communicates with MS1
2. The frontend allows to configure the connection and an x-api-key for MS2, which is stored in a MongoDb connected to MS1
3. The frontend has a chat that sends messages to MS1
4. MS1 receives messages and forwards them to MS2 (POST), adding the x-api-key to the request header
5. MS2 validates the key, manipulates the message and returns it (RESPONSE)
6. MS1 used the RESPONSE as its own RESPONSE for the Frontend
7. The frontend displays the response as a chat message from the counterpart

ARCHITECTURE
- Frontend - Angular9
- Microservices - .NET Core APIs
- MongoDb with Mongo Shell

SETUP
- Install dotnet core 3.1
- Install Node.js 12
- Install MongoDb

RUN
- /Microservice1/dotnet run
- /Microservice2/dotnet run
- /Frontend/npm install
- /Frontend/npm run start
- Go to http://localhost:4500/configure - Endpoint="http://localhost:6000/api/message" - Secret="secretkey"
- Go to http://localhost:4500/chat

DEBUG with VisualStudio Code
- Launch Microservice1
- Launch Microservice2
- Launch Frontend

TESTS
For a more complete example, tests should be written

UnitTests
- Frontend - unit tests for the frontend components and the service functions
- MS1 - unit tests for the DomainModel (mocking Repository and Microservice2)
- MS2 - unit test for the message response logic

IntegrationTests
- Microservice1 - Repository test for connection to MongoDb

E2E Tests
- Using Cypress or Protractor to test the Angular application
- Test to configure MS2
- Test to send chat messages


CLOSING
This is a very simple example. Authentication and Authorization must be solved accordingly. Frontends should not handle service connection secrets. A save way would be
an OAuth implementation where the user generates a OAuth code, and the Microservice1 uses it to get Token. Alternatively, the connection to MS2 must be configured in MS1 (server side), or the configuration from the Frontend must be limited to an authorized Admin account. 