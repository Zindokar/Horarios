CREATE TABLE Person (
  id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  username VARCHAR(255)  NOT NULL  ,
  pass VARCHAR(255)  NOT NULL  ,
  name VARCHAR(255)  NULL  ,
  mail VARCHAR(255)  NULL    ,
PRIMARY KEY(id));



CREATE TABLE Company (
  id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  name VARCHAR(255)  NOT NULL    ,
PRIMARY KEY(id));



CREATE TABLE PersonAudit (
  id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  person INTEGER UNSIGNED  NOT NULL  ,
  previousUsername VARCHAR(255)  NOT NULL  ,
  currentUsername VARCHAR(255)  NOT NULL  ,
  changedPass BOOL  NOT NULL  ,
  previousName VARCHAR(255)  NOT NULL  ,
  currentName VARCHAR(255)  NOT NULL  ,
  previousMail VARCHAR(255)  NOT NULL  ,
  currentMail VARCHAR(255)  NOT NULL  ,
  changedDate TIMESTAMP  NOT NULL    ,
PRIMARY KEY(id),
  FOREIGN KEY(person)
    REFERENCES Person(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);



CREATE TABLE CompanyAudit (
  id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  company INTEGER UNSIGNED  NOT NULL  ,
  previousName VARCHAR(255)  NOT NULL  ,
  currentName VARCHAR(255)  NOT NULL  ,
  changedDate TIMESTAMP  NOT NULL    ,
PRIMARY KEY(id),
  FOREIGN KEY(company)
    REFERENCES Company(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);



CREATE TABLE JobContract (
  person INTEGER UNSIGNED  NOT NULL  ,
  company INTEGER UNSIGNED  NOT NULL  ,
  startDate TIMESTAMP  NOT NULL  ,
  finishDate TIMESTAMP  NOT NULL  ,
  salaryPerHour FLOAT  NULL  ,
  position VARCHAR(255)  NULL    ,
PRIMARY KEY(person, company),
  FOREIGN KEY(person)
    REFERENCES Person(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(company)
    REFERENCES Company(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);



CREATE TABLE Schedule (
  id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  company INTEGER UNSIGNED  NOT NULL  ,
  person INTEGER UNSIGNED  NOT NULL  ,
  startDate TIMESTAMP  NOT NULL  ,
  finishDate TIMESTAMP  NOT NULL    ,
PRIMARY KEY(id),
  FOREIGN KEY(person, company)
    REFERENCES JobContract(person, company)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);



CREATE TABLE JobContractAudit (
  id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  compnay INTEGER UNSIGNED  NOT NULL  ,
  person INTEGER UNSIGNED  NOT NULL  ,
  previousPerson INTEGER UNSIGNED  NOT NULL  ,
  currentPerson INTEGER UNSIGNED  NOT NULL  ,
  previousCompany INTEGER UNSIGNED  NOT NULL  ,
  currentCompany INTEGER UNSIGNED  NOT NULL  ,
  previousStartDate TIMESTAMP  NOT NULL  ,
  currentStartDate TIMESTAMP  NOT NULL  ,
  previousSalaryPerHour FLOAT  NOT NULL  ,
  currentSalaryPerHour FLOAT  NOT NULL  ,
  previousPosition VARCHAR(255)  NOT NULL  ,
  currentPosition VARCHAR(255)  NOT NULL  ,
  changedDate TIMESTAMP  NOT NULL    ,
PRIMARY KEY(id),
  FOREIGN KEY(person, compnay)
    REFERENCES JobContract(person, company)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);



CREATE TABLE ScheduleAudit (
  id INTEGER UNSIGNED  NOT NULL   AUTO_INCREMENT,
  currentFinishDate TIMESTAMP  NOT NULL  ,
  schedule INTEGER UNSIGNED  NOT NULL  ,
  previousStartDate TIMESTAMP  NOT NULL  ,
  currentStartDate TIMESTAMP  NOT NULL  ,
  previousFinishDate TIMESTAMP  NOT NULL  ,
  previousCompany INTEGER UNSIGNED  NOT NULL  ,
  currentCompany INTEGER UNSIGNED  NOT NULL  ,
  previousPerson INTEGER UNSIGNED  NOT NULL  ,
  currentPerson INTEGER UNSIGNED  NOT NULL  ,
  changedDate TIMESTAMP  NOT NULL    ,
PRIMARY KEY(id, currentFinishDate),
  FOREIGN KEY(schedule)
    REFERENCES Schedule(id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION);




