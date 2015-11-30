using System;
using System.Collections.Generic;
using SessionStateSerialization;

namespace Helpers
{
    /// <summary>
    /// Persons entity
    /// </summary>
    [ClassDataTable("People")]
    [Serializable]
    public class Person
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [FieldDataColumn("FirstName")]
        public string FirstName { get; set;}

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [FieldDataColumn("LastName")]
        public string LastName { get; set;}

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        [FieldDataColumn("Age")]
        public int Age { get; set;}
    }

    /// <summary>
    /// Letters entity
    /// </summary>
    [ClassDataTable("letters")]
    [Serializable]
    public class Letters
    {
        /// <summary>
        /// Gets or sets the aa.
        /// </summary>
        /// <value>The aa.</value>
        [FieldDataColumn("aa")]
        public string aa { get; set;}

        /// <summary>
        /// Gets or sets the bb.
        /// </summary>
        /// <value>The bb.</value>
        [FieldDataColumn("bb")]
        public string bb { get; set;}

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        /// <value>The cc.</value>
        [FieldDataColumn("cc")]
        public int cc { get; set; }
    }

    /// <summary>
    /// Commplex entity
    /// </summary>
    public class ComplexEntity
    {
        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>The age.</value>
        [FieldDataColumn("Age")]
        public int Age { get; set;}

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>The persons.</value>
        [FieldDataColumn("persons")]
        public List<Person> persons { get; set; }

        /// <summary>
        /// Gets or sets the letters.
        /// </summary>
        /// <value>The letters.</value>
        [FieldDataColumn("letters")]
        public List<Letters> letters { get; set; }

    }
}
