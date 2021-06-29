CREATE TABLE Person (
  id SERIAL  NOT NULL ,
  username VARCHAR(255)   NOT NULL ,
  pass VARCHAR(255)   NOT NULL ,
  name VARCHAR(255)    ,
  mail VARCHAR(255)      ,
PRIMARY KEY(id));



CREATE TABLE Company (
  id SERIAL  NOT NULL ,
  name VARCHAR(255)   NOT NULL   ,
PRIMARY KEY(id));



CREATE TABLE PersonAudit (
  id SERIAL  NOT NULL ,
  person INTEGER   NOT NULL ,
  previousUsername VARCHAR(255)   NOT NULL ,
  currentUsername VARCHAR(255)   NOT NULL ,
  changedPass BOOL   NOT NULL ,
  previousName VARCHAR(255)   NOT NULL ,
  currentName VARCHAR(255)   NOT NULL ,
  previousMail VARCHAR(255)   NOT NULL ,
  currentMail VARCHAR(255)   NOT NULL ,
  changedDate TIMESTAMP   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(person)
    REFERENCES Person(id));



CREATE TABLE CompanyAudit (
  id SERIAL  NOT NULL ,
  company INTEGER   NOT NULL ,
  previousName VARCHAR(255)   NOT NULL ,
  currentName VARCHAR(255)   NOT NULL ,
  changedDate TIMESTAMP   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(company)
    REFERENCES Company(id));



CREATE TABLE JobContract (
  person INTEGER   NOT NULL ,
  company INTEGER   NOT NULL ,
  startDate TIMESTAMP   NOT NULL ,
  finishDate TIMESTAMP   NOT NULL ,
  salaryPerHour FLOAT    ,
  position VARCHAR(255)      ,
PRIMARY KEY(person, company),
  FOREIGN KEY(person)
    REFERENCES Person(id),
  FOREIGN KEY(company)
    REFERENCES Company(id));



CREATE TABLE Schedule (
  id SERIAL  NOT NULL ,
  company INTEGER   NOT NULL ,
  person INTEGER   NOT NULL ,
  startDate TIMESTAMP   NOT NULL ,
  finishDate TIMESTAMP   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(person, company)
    REFERENCES JobContract(person, company));



CREATE TABLE JobContractAudit (
  id SERIAL  NOT NULL ,
  compnay INTEGER   NOT NULL ,
  person INTEGER   NOT NULL ,
  previousPerson INTEGER   NOT NULL ,
  currentPerson INTEGER   NOT NULL ,
  previousCompany INTEGER   NOT NULL ,
  currentCompany INTEGER   NOT NULL ,
  previousStartDate TIMESTAMP   NOT NULL ,
  currentStartDate TIMESTAMP   NOT NULL ,
  previousSalaryPerHour FLOAT   NOT NULL ,
  currentSalaryPerHour FLOAT   NOT NULL ,
  previousPosition VARCHAR(255)   NOT NULL ,
  currentPosition VARCHAR(255)   NOT NULL ,
  changedDate TIMESTAMP   NOT NULL   ,
PRIMARY KEY(id),
  FOREIGN KEY(person, compnay)
    REFERENCES JobContract(person, company));



CREATE TABLE ScheduleAudit (
  id SERIAL  NOT NULL ,
  currentFinishDate TIMESTAMP   NOT NULL ,
  schedule INTEGER   NOT NULL ,
  previousStartDate TIMESTAMP   NOT NULL ,
  currentStartDate TIMESTAMP   NOT NULL ,
  previousFinishDate TIMESTAMP   NOT NULL ,
  previousCompany INTEGER   NOT NULL ,
  currentCompany INTEGER   NOT NULL ,
  previousPerson INTEGER   NOT NULL ,
  currentPerson INTEGER   NOT NULL ,
  changedDate TIMESTAMP   NOT NULL   ,
PRIMARY KEY(id, currentFinishDate),
  FOREIGN KEY(schedule)
    REFERENCES Schedule(id));




