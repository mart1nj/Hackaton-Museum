using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Common;
using Open.Domain.Common;
namespace Open.Tests.Domain
{
    [TestClass] public abstract class EntityBaseTests<TObject, TRecord> : ObjectTests<TObject> 
        where TObject: Period<TRecord> 
        where TRecord: PeriodData, new() {
        protected TObject createdWithNullArg;
        protected Type dbRecordType;

        [TestMethod] public void DataTest() {
            Assert.IsNotNull(obj.Data);
            Assert.IsInstanceOfType(obj.Data, dbRecordType);
        }

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(createdWithNullArg.Data);
            Assert.IsInstanceOfType(createdWithNullArg.Data, dbRecordType);
        }
        [TestMethod]
        public void DataIsReadOnlyTest()
        {
            /*var name = GetMember.Name<Account>(x => x.Data);
            Assert.IsTrue(IsReadOnly.Field<Account>(name));*/
            Assert.Inconclusive();
        }
    }
}



