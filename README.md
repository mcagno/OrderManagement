#OrderManagement project

##Purpose
The project has the purpose to create an example of a small order management system composed by:
- a backend using .NET WebAPI (RESTful), DDD, Dependency injection
- an example of client API library accessing the WebAPI

##Assembly description

The solution is composed by the following project.

###OrderManagement.WebAPI
The project contains the Web service layer for the backend, in order to perform the actions 

###OrderManagement.Domain
The project contains the domain classes needed for the backend.

###OrderManagement.DTO
The project contains the DTO classes needed to instantiate the communication between the client and the WebAPI. This project, although not striclty needed, is used by both the backend and the client API

###OrderManagement.Assembler
The project contains the classes that performs the translations between DTO and domain classes.

###OrderManagement.Repository
The project contains repositories in order to simulate a system that store and retrieve instances. In this example the instances are stored in memory in static lists.

###OrderManagement.ClientAPI
The project contains the client API that can be used to compose an order.
By using the OrderManager class is possible to create/edit/delete orders.

###OrderManagement.ClientAPI.Tests
The project contains a series of e2e test, to simulate the operativity.
_Note: the tests have been written with the purpose to use the client library and not to provide a complete unit tests suite for it.

##Notes
During the realization of this project the following assumptions have been made:
* the authentication and authorization of the user is managed externally, no security has been introduced
* the purchase, shipping and fulfillment of the order is not managed
* due to a lack of time, error cases (order not existent, product not existent, invalid price etc.) have not been written