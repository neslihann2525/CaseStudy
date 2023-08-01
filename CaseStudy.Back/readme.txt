

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
(N'S�et Ceket', 129.99, 40),
(N'Bluetooth Hoparl�r', 79.50, 65),
(N'Kad�n �anta', 44.95, 55),
(N'Spor �ortu', 29.99, 110),
(N'Di� Beyazlatma Seti', 54.25, 25),
(N'Deri C�zdan', 39.99, 75),
(N'Kahve Makinesi', 89.00, 30),
(N'Mikrofiber Havlu Seti', 19.50, 90),
(N'Polar Yelek', 49.99, 80),
(N'Kulak Temizleme �ubu�u', 5.95, 200),
(N'G�m�� Kolye', 74.75, 15),
(N'Fitness Bilekli�i', 34.50, 70),
(N'Y�zme G�zl���', 12.99, 150),
(N'Deniz Sandaleti', 17.95, 100),
(N'Yatak Minderi', 25.00, 45),
(N'Kettle Su Is�t�c�', 59.99, 35),
(N'Saatlik Park �creti', 7.50, 500),
(N'Ev Terli�i', 9.25, 120),
(N'Yemek Seti', 44.50, 60),
(N'Travel Boy Makyaj Seti', 28.95, 40),
(N'Sporcu S�rt �antas�', 39.99, 50),
(N'Suni Deri Eldiven', 14.50, 90),
(N'Kahve Fincan� Seti', 34.95, 55),
(N'Ku� Yuvas�', 8.99, 300),
(N'Kolye ve K�pe Tak�m�', 54.75, 20),
(N'Y�z Temizleme Jeli', 19.50, 75),
(N'Y�r�me Band�', 499.00, 10),
(N'Bardak Altl���', 6.25, 200),
(N'Kahve ���t�c�', 69.99, 30),
(N'Dayan�kl� Powerbank', 29.50, 85),
(N'Polar Bere', 12.99, 110),
(N'Duvar Saati', 34.95, 65),
(N'Yast�k K�l�f�', 9.75, 150),
(N'Bluetooth Oyun Kumandas�', 39.50, 40),
(N'Kurutma Makinesi', 79.99, 25),
(N'Saklama Kab� Seti', 22.50, 95),
(N'Sa� Ma�as�', 32.75, 70),
(N'Yatak �rt�s�', 45.99, 50),
(N'Fermuarl� Kap�onlu Sweatshirt', 29.95, 120),
(N'Temizlik Bezi Seti', 16.50, 180),
(N'Spinner Oyuncak', 8.99, 300),
(N'�ok Ama�l� B��ak Seti', 59.50, 20),
(N'Dekoratif Yast�k', 12.75, 100),
(N'Puzzle Oyunu', 24.99, 45),
(N'Y�zme �apkas�', 6.95, 180),
(N'Ah�ap �er�eve', 18.50, 60),
(N'Su Ge�irmez Cep Telefonu K�l�f�', 19.99, 70),
(N'Travel Boy Di� F�r�as�', 3.50, 250),
(N'Yemek Tak�m�', 39.95, 30);
