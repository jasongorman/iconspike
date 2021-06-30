using System;
using System.IO;

namespace context
{
	/// <summary>
	/// Summary description for IResponse.
	/// </summary>
	public interface IResponse
	{

		Stream OutputStream	{get;}

		string ContentType {get; set;}
		
		void end();
	}
}
