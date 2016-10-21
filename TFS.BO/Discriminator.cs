using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace TFS.BO
{
    public class Discriminator
    {
        private static Discriminator _instance = new Discriminator();
        private static bool _isRegistered = false;

        public static Discriminator Instance
        {
            get { return _instance; }
        }

        public bool IsRegistered
        {
            get { return _isRegistered; }
        }

        public void Register()
        {
            if (_isRegistered) return;

            _isRegistered = true;

            RegisterWorkItemTypeBO();

//            var pack = new ConventionPack();
//            pack.Add(new StringObjectIdConvention());
//            ConventionRegistry.Register("DiscriminatorConventions", pack, x => true);

            
            var dateTimeSerializer = new DateTimeSerializer(DateTimeKind.Local,BsonType.DateTime);
            BsonSerializer.RegisterSerializer(typeof(DateTime), dateTimeSerializer);

//            RegisterUserObject();
//            RegisterUserElement();
        }

        private void RegisterWorkItemTypeBO()
        {
            BsonClassMap.RegisterClassMap<WorkItemTypeBO>(
                cm => {
                    cm.AutoMap();
                    cm.MapIdProperty(x => x._id);
                    cm.SetIdMember(cm.GetMemberMap(x=>x._id));

                    cm.SetExtraElementsMember(cm.GetMemberMap(x => x.NonMappedFields));
                });

        }

        //        private void RegisterUserObject()
        //        {
        //            BsonClassMap.RegisterClassMap<UserObject>(
        //                cm => {
        //                    cm.AutoMap();
        //                    cm.MapIdProperty(x => x._id);
        //                    cm.IdMemberMap.SetRepresentation(BsonType.ObjectId);
        //                    cm.SetExtraElementsMember(cm.GetMemberMap(x => x.NonMappedFields));
        //                    cm.GetMemberMap(x => x.IsActive).SetIgnoreIfNull(true);
        //                    cm.GetMemberMap(x => x.IsCollection).SetIgnoreIfNull(true);
        //                });
        //        }
        //
        //        private void RegisterUserElement()
        //        {
        //            BsonClassMap.RegisterClassMap<UserElement>(
        //                cm => {
        //                    cm.AutoMap();
        //                    cm.GetMemberMap(x => x.DataType).SetRepresentation(BsonType.String);
        //                });
        //        }

        //        private class StringObjectIdConvention : ConventionBase, IPostProcessingConvention
        //        {
        //            public void PostProcess(BsonClassMap classMap)
        //            {
        //                var idMap = classMap.IdMemberMap;
        //                if (idMap != null && idMap.MemberName == "_id" && idMap.MemberType == typeof(string))
        //                {
        //                    idMap.ClassMap.
        //                    idMap.SetRepresentation(BsonType.ObjectId);
        //                    idMap.SetIdGenerator(new StringObjectIdGenerator());
        //                }
        //            }
        //        }
    }
}
