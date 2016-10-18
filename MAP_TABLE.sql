CREATE Or Replace TRIGGER t1
BEFORE INSERT OR UPDATE Of Population On CIties
FOR EACH ROW
BEGIN
case
  WHEN INSERTING THEN  DBMS_OUTPUT.put_line('Inserting'||:new.City);
  WHEN UPDATING('Population') THEN DBMS_OUTPUT.put_line('Updating '||:old.Population||' to '|| :new.Population);
END CASE;
END t1;

Set Serveroutput on; 

INSERT INTO Cities(ID,City,IDCountry)
VALUES(105,'Argh!',1);

Update Cities SET population = 500 WHERE ID = 2;



CREATE View CANDC AS SELECT City, Country,population FROM CITIES,COUNTRIES Where Countries.ID=IDCOUNTRY;

CREATE Or Replace TRIGGER t2
INSTEAD OF INSERT ON CANDC
FOR EACH ROW
BEGIN
case
  WHEN INSERTING THEN  DBMS_OUTPUT.put_line('Inserting '||:new.City||' '|| :new.Country||' '||:new.Population);
END CASE;
END t2;

Insert Into CANDC (Country,City,Population)
Values ('France','Paris',1000);