

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




## Example Product Inserts

INSERT INTO dbo.Product (Name, Price, Quantity) VALUES
(N'Süet Ceket', 129.99, 40),
(N'Bluetooth Hoparlör', 79.50, 65),
(N'Kadýn Çanta', 44.95, 55),
(N'Spor Þortu', 29.99, 110),
(N'Diþ Beyazlatma Seti', 54.25, 25),
(N'Deri Cüzdan', 39.99, 75),
(N'Kahve Makinesi', 89.00, 30),
(N'Mikrofiber Havlu Seti', 19.50, 90),
(N'Polar Yelek', 49.99, 80),
(N'Kulak Temizleme Çubuðu', 5.95, 200),
(N'Gümüþ Kolye', 74.75, 15),
(N'Fitness Bilekliði', 34.50, 70),
(N'Yüzme Gözlüðü', 12.99, 150),
(N'Deniz Sandaleti', 17.95, 100),
(N'Yatak Minderi', 25.00, 45),
(N'Kettle Su Isýtýcý', 59.99, 35),
(N'Saatlik Park Ücreti', 7.50, 500),
(N'Ev Terliði', 9.25, 120),
(N'Yemek Seti', 44.50, 60),
(N'Travel Boy Makyaj Seti', 28.95, 40),
(N'Sporcu Sýrt Çantasý', 39.99, 50),
(N'Suni Deri Eldiven', 14.50, 90),
(N'Kahve Fincaný Seti', 34.95, 55),
(N'Kuþ Yuvasý', 8.99, 300),
(N'Kolye ve Küpe Takýmý', 54.75, 20),
(N'Yüz Temizleme Jeli', 19.50, 75),
(N'Yürüme Bandý', 499.00, 10),
(N'Bardak Altlýðý', 6.25, 200),
(N'Kahve Öðütücü', 69.99, 30),
(N'Dayanýklý Powerbank', 29.50, 85),
(N'Polar Bere', 12.99, 110),
(N'Duvar Saati', 34.95, 65),
(N'Yastýk Kýlýfý', 9.75, 150),
(N'Bluetooth Oyun Kumandasý', 39.50, 40),
(N'Kurutma Makinesi', 79.99, 25),
(N'Saklama Kabý Seti', 22.50, 95),
(N'Saç Maþasý', 32.75, 70),
(N'Yatak Örtüsü', 45.99, 50),
(N'Fermuarlý Kapþonlu Sweatshirt', 29.95, 120),
(N'Temizlik Bezi Seti', 16.50, 180),
(N'Spinner Oyuncak', 8.99, 300),
(N'Çok Amaçlý Býçak Seti', 59.50, 20),
(N'Dekoratif Yastýk', 12.75, 100),
(N'Puzzle Oyunu', 24.99, 45),
(N'Yüzme Þapkasý', 6.95, 180),
(N'Ahþap Çerçeve', 18.50, 60),
(N'Su Geçirmez Cep Telefonu Kýlýfý', 19.99, 70),
(N'Travel Boy Diþ Fýrçasý', 3.50, 250),
(N'Yemek Takýmý', 39.95, 30);
