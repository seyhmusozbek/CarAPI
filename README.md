# CarAPI
It is an api that stores car details and retrieves them.
It uses MSSQL Server as database. I used Entity Framework Code First approach as the ORM. To manage data access I used Generic Repository with UnitOfWork approach. 
It has 3 end points as;
● Login (POST):
/api/challenge/Login
Payload request: { "Username": "test-user", "Password": "test1234" }
Response class (Status 200): { "AddressToken": "string"}
● GetCars (GET):
/api/challenge/GetCars
Header: {"Authorization": "Bearer string"}
Response class (Status 200): {"cars": [{"Id": "number", "Brand": "string", "Model": "string",
"Navigation":"boolean" } ]}
● AddCar (POST):
/api/challenge/AddCar
Header: {"Authorization": "Bearer string"}
Payload request class: {"Brand": "string", "Model": "string", "Navigation": "boolean" }
Response class (Status 200): {"Id": "number", "Brand": "string", "Model": "string", "Navigation":
"boolean" }
