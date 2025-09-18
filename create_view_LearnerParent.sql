   
   CREATE VIEW LearnerParentView 
    AS
        SELECT 
            l.LearnerId,
            l.FirstName AS LearnerFirstName,
            l.LastName AS LearnerLastName,
            l.Grade,
            l.Stream,
            p.ParentId,
            p.Relationship AS ParentRelationship,
            p.FirstName AS ParentFirstName,
            p.LastName AS ParentLastName,
            p.Gender AS ParentGender,
            p.Email AS ParentEmail,
            p.Cell AS ParentCell
        FROM dbo.LearnerBio l
            INNER JOIN dbo.ParentBio p
                ON l.LearnerId = p.LearnerId
