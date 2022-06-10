create schema if not exists city;

use city;

create table if not exists Countries
(
    Id varchar(36) primary key,
    CountryName varchar(50),
    Population int,
    Area decimal
);

create table if not exists Cities
(
    Id varchar(36) primary key,
    CountryId varchar(36),
    constraint countryId_fk
    foreign key (CountryId) references Countries(Id),
    CityName varchar(50),
    Population int,
    Area decimal
);

create table if not exists Districts
(
    Id varchar(36) primary key,
    CityId varchar(36),
    constraint cityId_fk
    foreign key (CityId) references Cities (Id),
    DistrictName varchar(50),
    Area decimal
);
create table if not exists Streets
(
    Id varchar(36) primary key,
    DistrictId varchar(36),
    constraint districtId_fk
    foreign key (DistrictId) references Districts (Id),
    StreetName varchar(50),
    PostalCode varchar(10)
);

create table if not exists Houses
(
    Id varchar(36) primary key,
    StreetId varchar(36),
    constraint streetId_fk
    foreign key (StreetId) references Streets (Id),
    Number varchar(5)
);

create table if not exists PersonHouse
(
    Id varchar(36) primary key,
    PersonId varchar(36),
    constraint personId_fk
    foreign key (PersonId) references Persons (Id),
    HouseId varchar(36),
    constraint houseId_fk
    foreign key (HouseId) references Houses (Id)
);

create table if not exists Persons
(
    Id varchar(36) primary key,
    FirstName varchar(30),
    LastName varchar(30),
    Sex varchar(10),
    Position varchar(50)
);

create table if not exists Factories
(
    Id varchar(36) primary key,
    DistrictId varchar(30),
    constraint districtId_factories_fk
    foreign key (DistrictId) references Districts (Id),
    FactoryName varchar(50),
    Product varchar(50)
);

create table if not exists PersonFactory
(
    Id varchar(36) primary key,
    PersonId varchar(36),
    constraint personId_factory_fk
    foreign key (PersonId) references Persons (Id),
    FactoryId varchar(36),
    constraint factoryId_fk
    foreign key (FactoryId) references Factories (Id)
);

insert into Countries(Id, CountryName, Population, Area) value (UUID(), 'Test', 1, 9999);

select * from Countries;

select * from Cities;