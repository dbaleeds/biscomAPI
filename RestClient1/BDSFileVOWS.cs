using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class BDSFileVOWS
    {
    public int id{get;set;}
	public int datafileId{get;set;}
	public String name{get;set;}
	public String description{get;set;}
	public long size{get;set;}
	public Boolean isDirectory{get;set;}
	public int parentDirectoryId{get;set;}
	public int rootDirectoryId{get;set;}
	public String parsedDateCreated{get;set;}
    
        /*public List<BDSFileVOWS> children = new List<BDSFileVOWS>();
    public List<BDSFileVOWS> Children
    {
        get { return children; }
        set { children = value; }
    }*/
	
    }
}
