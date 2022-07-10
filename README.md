# CarAPI
It is a .net5.0 api that stores car details and retrieves them.
It uses MSSQL Server as database. <br />I used Entity Framework Code First approach as the ORM. To manage data access I used Generic Repository with UnitOfWork approach. 
It has 3 end points as;<br />
● <b>Login</b> (POST):<br />
/api/challenge/Login<br />
Payload request: { "Username": "test-user", "Password": "test1234" }<br />
Response class (Status 200): { "AddressToken": "string"}<br />
● <b>GetCars</b> (GET):<br />
/api/challenge/GetCars<br />
Header: {"Authorization": "Bearer string"}<br />
Response class (Status 200): {"cars": [{"Id": "number", "Brand": "string", "Model": "string",<br />
"Navigation":"boolean" } ]}<br />
● <b>AddCar</b> (POST):<br />
/api/challenge/AddCar<br />
Header: {"Authorization": "Bearer string"}<br />
Payload request class: {"Brand": "string", "Model": "string", "Navigation": "boolean" }<br />
Response class (Status 200): {"Id": "number", "Brand": "string", "Model": "string", "Navigation":<br />
"boolean" }<br />
