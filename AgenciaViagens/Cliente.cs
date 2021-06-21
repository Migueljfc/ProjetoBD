using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaViagens
{
	[Serializable()]
	class Cliente
	{
		private int _id;
		private String _nome;
		private String _apelido;
		private String _email;
		private int _CC;
		private int _telefone;

		public int ID
        {
			get { return _id; }
			set { _id = value; }
		}
		public int ClientCC
		{
			get { return _CC; }
			set
			{
				if (value.Equals(null) | value.Equals(" "))
				{
					throw new Exception("O Cliente tem que ter um numero de identificação (CC) ");
					return;
				}
				_CC = value;
			}
		}

		public int Telefone
		{
			get { return _telefone; }
			set { _telefone = value; }
		}


		public String Nome
		{
			get { return _nome; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O Cliente tem que ter um nome ");
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
					throw new Exception("O Cliente tem que ter um apelido ");
					return;
				}
				_apelido = value;
			}
		}

		public String Email
		{
			get { return _email; }
			set { _email = value; }
		}

		public override String ToString()
		{
			return _nome + " " + _apelido + " CC: " + _CC;
		}
	}
}
