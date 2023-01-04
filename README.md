# C# Restful API Service to analyze JSON product data

Create a simple C#/.NET Restful API service, that
- reads from any URL with JSON-Data a list of product data.
The URL to read from is given below and contains mostly beers.
- has three different routes and questions to analyse the JSON-Data given.
   - Most expensive and cheapest beer per litre.
   - Which beers cost exactly ˆ17.99?
Order the result by price per litre (cheapest first).
   - Which one product comes in the most bottles?
- It also has one route to get the answer to all routes or questions at once.
- Any result or output should be in JSON, too.

A route may look like this: /api/mostBottles?url=http://urlto/productData.json
However the structure and naming of the routes is up to you and also part of your task.

You are invited to use and include whatever assets you find from our actual websites (as long as you
don’t host them publicly) in case you need/want to. You may use any tools that you like to
accomplish this task, including build/dependency management, IDE/editor, libraries, etc.

We should be able to build and run your project without needing to make any changes to it in a
recent version of a typical developer’s environment.

The URL for the JSON-Data is the following:

https://flapotest.blob.core.windows.net/test/ProductData.json

## Demo Site

[Swagger UI](https://testapi20220723.azurewebsites.net/swagger/index.html)

Endpoints:

- [api/beer/all](https://testapi20220723.azurewebsites.net/api/beer/all?url=https%3A%2F%2Fflapotest.blob.core.windows.net%2Ftest%2FProductData.json)
- [api/beer/price-exactly-17-99](https://testapi20220723.azurewebsites.net/api/beer/price-exactly-17-99?url=https%3A%2F%2Fflapotest.blob.core.windows.net%2Ftest%2FProductData.json)
- [api/beer/cheapest-and-most-expensive-beers-per-liter](https://testapi20220723.azurewebsites.net/api/beer/cheapest-and-most-expensive-beers-per-liter?url=https%3A%2F%2Fflapotest.blob.core.windows.net%2Ftest%2FProductData.json)
- [api/beer/most-bottles](https://testapi20220723.azurewebsites.net/api/beer/most-bottles?url=https%3A%2F%2Fflapotest.blob.core.windows.net%2Ftest%2FProductData.json)
