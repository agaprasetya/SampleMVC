DROP DATABASE IF EXISTS webone;
CREATE DATABASE webone;
USE webone;

CREATE TABLE people (
    id int(11) NOT NULL AUTO_INCREMENT,
    first_name varchar(20) DEFAULT NULL,
    last_name varchar(20) DEFAULT NULL,
    birth_date date DEFAULT NULL,
    PRIMARY KEY (id)
);

insert into people (first_name) value('Aga');

DELIMITER //
CREATE PROCEDURE `webone`.`ShowAll`()
BEGIN
SELECT 
  people.id, 
  people.first_name, 
  people.last_name, 
  people.birth_date
FROM
  webone.people;
END
DELIMITER ;