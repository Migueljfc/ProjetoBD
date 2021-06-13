using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace AgenciaViagens
{

	[Serializable()]
	public class Admin
	{
		private String _ID;
		private String _nome;
		private String _apelido;
		private String _password;
		

		public String AdminID
		{
			get { return _ID; }
			set { _ID = value; }
		}


		public String Name
		{
			get { return _nome; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O Administrador tem que ter um nome ");
					return;
				}
				_nome = value;
			}
		}

		public String Apelido
		{
			get { return _apelido; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O Administrador tem que ter um apelido ");
					return;
				}
				_apelido = value;
			}
		}

		public String Password
		{
			get { return _password; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O Administrador tem que ter password ");
					return;
				}
				_password = value;
			}
		}

		public override String ToString()
		{
			return _nome + " " + _apelido + " " + _ID ;
		}

		
	}
}

