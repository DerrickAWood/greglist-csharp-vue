CREATE TABLE cars(
 id INT NOT NULL AUTO_INCREMENT,
 make VARCHAR(255) NOT NULL,
 model VARCHAR(255) NOT NULL,
 imgUrl VARCHAR(255) NOT NULL,
 decription VARCHAR(255) NOT NULL,
 productionYear INT NOT NULL,
 price INT NOT NULL,
 userId VARCHAR(255) NOT NULL, 
 PRIMARY KEY (id) 
)

-- DROP TABLE cars

-- INSERT INTO cars
-- (make, model, imgUrl, decription, productionYear, price, userId)
-- VALUES
-- ("Chevy", "Tahoe", "img", "its a tahoe", 2012, 25000, "id")
