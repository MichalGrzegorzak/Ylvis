using MbUnit.Framework;
using Rhino.Commons;
using Stock.Core.Domain;

namespace Stock.Test
{
    [TestFixture]
    public class EmployeeFixture : BasePersistanceFixture
    {
        [Test]
        public void CanSaveCustomer()
        {
            Employee Customer = CreateNewCustomer();
            Assert.AreEqual(0, Customer.ID);

            Repository<Employee>.Save(Customer); //save
            UnitOfWork.Current.TransactionalFlush();
            UnitOfWork.CurrentSession.Evict(Customer);
            Employee fromDb = Repository<Employee>.Get(Customer.ID); //get
            
            Assert.AreNotSame(Customer, fromDb);
            Assert.AreEqual("Ayende", fromDb.LastName);
            Assert.AreEqual("ayende@ayende.com", fromDb.Address);
            Assert.AreEqual(Customer.ID, fromDb.ID);
        }

        private Employee CreateNewCustomer()
        {
            Employee Customer = new Employee();
            Customer.FirstName = "Ayende22";
            Customer.LastName = "Ayende";
            Customer.Address = "ayende@ayende.com";
            return Customer;
        }

    }
}