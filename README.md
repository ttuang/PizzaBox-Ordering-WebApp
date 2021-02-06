pizzabox
The goal of the project is to build a Pizza Ordering System.

architecture (REQUIRED)
[solution] PizzaBox.sln
[project - MVC] PizzaBox.Client.csproj
OrderController, UserController, StoreController
[project - ClassLib] PizzaBox.Domain.csproj
think about abstraction, design patterns
implement Models
[project - ClassLib ] PizzaBox.Storing.csproj
implement at least 1 repository
[project - xunit] PizzaBox.Testing.csproj
implement unit testing
requirements
The project should support objects of Customer, Store, Order, Pizza.

store
[required] there should exist at least 2 stores for a user to choose from
[required] each store should be able to view/list any and all of their completed/placed orders
[required] each store should be able to view/list any and all of their sales (amount of revenue weekly or monthly)
order
[required] each order must be able to view/list/edit its collection of pizzas
[required] each order must be able to compute its pricing
[required] each order must be limited to a total pricing of no more than $250
[required] each order must be limited to a collection of pizzas of no more than 50
pizza
[required] each pizza must be able to have a crust
[required] each pizza must be able to have a size
[required] each pizza must be able to have toppings
[required] each pizza must be able to compute its pricing
[required] each pizza must have no less than 2 default toppings
[required] each pizza must limit its toppings to no more 5
customer
[required] must be able to view/list its order history
[required] must be able to only order from 1 location in a 24-hour period with no reset
[required] must be able to only order once every 2-hour period
technologies
.NET Core - ASP.NET Core MVC
.NET Core - C#
.NET Core - EF + SQL
.NET Core - xUnit

customer story
as a customer, i should be able to do this:

access the application
see a list of locations
select a location
place an order
with either custom or preset pizzas
if custom
select crust, size and toppings
if preset
select pizza and its size
see a tally of my order
add or remove more pizzas
and checkout when complete with latest order
see my order history
make a new order
store story
as a store, i should be able do this:

access the application
select options for order history, sales
if order history
select options for all store orders and orders associated to a user (filtering)
if sales
see pizza type, count, revenue by week or by month
the goal is to try to complete as many reqs as you can in the time alloted.