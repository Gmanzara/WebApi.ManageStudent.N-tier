using MongoDB.Bson;

namespace ManageStudent.API.Ressources
{
    public class ComposerRessource
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
