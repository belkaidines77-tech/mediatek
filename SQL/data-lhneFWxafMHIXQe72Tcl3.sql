DROP TABLE IF EXISTS `myTable`;

CREATE TABLE `myTable` (
  `id` mediumint(8) unsigned NOT NULL auto_increment,
  `nom` varchar(255) default NULL,
  `prenom` varchar(255) default NULL,
  `tel` varchar(100) default NULL,
  `mail` varchar(255) default NULL,
  `idservice` varchar(255) default NULL,
  PRIMARY KEY (`id`)
) AUTO_INCREMENT=1;

INSERT INTO `myTable` (`nom`,`prenom`,`tel`,`mail`,`idservice`)
VALUES
  ("Espinoza","Ciaran","06 17 81 49 17","aenean.euismod@hotmail.ca","1"),
  ("Fuentes","Amela","09 53 41 75 72","ante.nunc@hotmail.com","1"),
  ("Morton","Hedley","01 75 58 92 08","porttitor.tellus.non@hotmail.edu","3"),
  ("Stephenson","Raymond","03 72 10 32 38","non.feugiat@protonmail.ca","3"),
  ("Irwin","Hannah","09 03 14 56 82","primis.in.faucibus@yahoo.ca","1"),
  ("Parks","Nash","07 45 56 88 05","magna@google.org","1"),
  ("Silva","Jaden","01 46 65 33 61","nunc@yahoo.edu","2"),
  ("Riddle","Xyla","06 95 37 80 15","nulla.semper.tellus@hotmail.net","2"),
  ("Serrano","Jillian","01 61 48 93 90","viverra@icloud.couk","1"),
  ("Parks","Graiden","01 31 31 67 14","enim.suspendisse@hotmail.net","2");
