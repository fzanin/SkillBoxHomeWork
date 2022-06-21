using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework_11_Protective_Proxy_Example
{
    public class Document
    {
        public Document (string name, string content)
        {
            Name = name;
            Content = content;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<string> Tags { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCerated { get; private set; } = DateTime.UtcNow;
        public DateTime DateReviewed { get; private set; } = DateTime.UtcNow;
    }

    public enum Roles
    {
        Author,
        Editor
    }

    public class User
    {
        public string Name { get; set; }
        public Roles Role { get; set; }
        public List<Document> AuthoredDocuments { get; } = new List<Document>();

        public void AddDocument(string documentName, string documentContent)
        {
            var document = new Document(documentName, documentContent);
            AuthoredDocuments.Add(document);
        }


        //public class UserAddDocument
        //{
        //    [Fact]
        //    public void AddsDocumentToAuthoredDocuments()
        //    {
        //        var author = new User { Role = Roles.Author };

        //        author.AddDocument("test name", "test content");

        //        Assert.Contains(author.AuthoredDocuments, doc => doc.Name == "test name");
        //    }
        //}


    }





}
