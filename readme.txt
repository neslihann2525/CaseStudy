

Some technologies for this project like the below;

- N Layer Architecture
	Data, Business, Dto, Entities, WebApi
- UOW Pattern
	I have the UOW Pattern for this project because it has the need for multiple dependencies in the process control architecture.
- Factory Pattern
	I used Factory Pattern to CartManager as becoming an example.
- Generic Repository Pattern
	I used the Generic Repository Pattern that Managers except for CartManager.
- Mapping
	I used IMapper to relate Entities Models and Dtos Models.
- Dto conversion
	I used DTO models I need their properties in the Entities Model.
- Code Fist Migration
	I created DbSets with the Code First approach and used EntityConfigurations.
- RabbitMQ Queue
	I used RabbitMQ Queue because there would be concurrent mail requests, there would be a problem on a large website, and it could be a problem on the application server or database instance, etc. when I was trying to send an email. So I queued up the email, and I didn't wait for it.