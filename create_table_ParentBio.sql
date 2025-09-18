
    CREATE TABLE ParentBio (
        ParentId INT IDENTITY(1, 1) PRIMARY KEY,
        LearnerId INT NOT NULL, 
        Relationship VARCHAR(55) NOT NULL
            CHECK(Relationship IN ('Mother', 'Father')),
        FirstName VARCHAR(55) NOT NULL,
        MiddleName VARCHAR(55) NULL,
        LastName VARCHAR(55) NOT NULL,
        Gender VARCHAR(10) NOT NULL
            CHECK(Gender IN ('Male', 'Female')),
        IDNumber VARCHAR(20) NOT NULL,
        Email VARCHAR(255) NOT NULL UNIQUE,
        Cell VARCHAR(20) NOT NULL UNIQUE,
        CreatedAt DATETIME DEFAULT GETDATE(),
            CONSTRAINT FK_ParentBio_LearnerBio 
            FOREIGN KEY (LearnerId)
                REFERENCES LearnerBio(LearnerId)
                    ON DELETE CASCADE
                    ON UPDATE CASCADE   
    )
