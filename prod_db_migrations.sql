
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Author` (
    `AuthorId` int NOT NULL AUTO_INCREMENT,
    `FirstName` longtext CHARACTER SET utf8mb4 NULL,
    `LastName` longtext CHARACTER SET utf8mb4 NULL,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `Isbn` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Author` PRIMARY KEY (`AuthorId`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Assignment` (
    `BookId` int NOT NULL AUTO_INCREMENT,
    `AuthorId` int NOT NULL,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `Isbn` longtext CHARACTER SET utf8mb4 NULL,
    `Author` longtext CHARACTER SET utf8mb4 NULL,
    `Published` datetime(6) NOT NULL,
    CONSTRAINT `PK_Assignment` PRIMARY KEY (`BookId`),
    CONSTRAINT `FK_Assignment_Author_AuthorId` FOREIGN KEY (`AuthorId`) REFERENCES `Author` (`AuthorId`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Assignment_AuthorId` ON `Assignment` (`AuthorId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241126221039_initialCommit', '8.0.11');

COMMIT;


