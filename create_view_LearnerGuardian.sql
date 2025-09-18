    
    CREATE VIEW LearnerGuardianView 
    AS
        SELECT 
            l.LearnerId,
            l.FirstName AS LearnerFirstName,
            l.LastName AS LearnerLastName,
            l.Grade,
            l.Stream,
            g.GuardianId,
            g.Relationship AS GuardianRelationship,
            g.FirstName AS GuardianFirstName,
            g.LastName AS GuardianLastName,
            g.Gender AS GuardianGender,
            g.Email AS GuardianEmail,
            g.Cell AS GuardianCell
        FROM dbo.LearnerBio l
            INNER JOIN dbo.GuardianBio g
                ON l.LearnerId = g.LearnerId
