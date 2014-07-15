using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioPM.Controller.Object
{
    public class Competency : BioPM.Controller.Helper.ITreeNode<Competency>
    {
        //Current Node Information
        protected int _competencyId;
        protected string _competencyName;
        protected string _navUrl;
        protected string _iconClass;
	//Pointer into Parent Node (ParentId will be the _organizationId of this _parent object)
        protected Competency _parent;
	//Pointer into Children Node
        protected IList<Competency> _children;

	/// <summary>
	/// Using ITreeNode Helper Function, which is a helper function to convert flat array into tree node
	/// We have to implement the ITreeNode interface (ITreeNode<ClassObject>) into the object class (using inheritance)
	/// We also have to provide at least three properties in the object class with pointed name and type, as because it was available in the Interface
	/// so we have to implement it. The three properties are :
	/// Id : Int
	/// Parent : Class Object
	/// Children : IList<ClassObject>
	/// </summary>

        public int Id
        {
            get { return _competencyId; }
            set { _competencyId = value; }
        }

        public string CompetencyName
        {
            get { return _competencyName; }
            set { _competencyName = value; }
        }

        public string NavUrl
        {
            get { return _navUrl; }
            set { _navUrl = value; }
        }

        public string IconClass
        {
            get { return _iconClass; }
            set { _iconClass = value; }
        }

	public Competency Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

	public IList<Competency> Children
	{
	    get { return _children; }
	    set { _children = value; }
	}

        public Competency() { }

        public Competency(int competencyId, string competencyName, Competency parentId)
        {
            _competencyId = competencyId;
            _competencyName = competencyName;
            _parent = parentId;
        }

        public Competency(int competencyId, string competencyName, Competency parentId, string navUrl, string iconClass)
        {
            _competencyId = competencyId;
            _competencyName = competencyName;
            _parent = parentId;
            _navUrl = navUrl;
            _iconClass = iconClass;
        }
    }
}