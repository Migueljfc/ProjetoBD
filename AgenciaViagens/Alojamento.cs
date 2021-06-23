using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaViagens
{
	class Alojamento
	{
		private int _ID;
		private string _tipo;
		private string _nome;
		private int _preco;

		public int AlojID
		{
			get { return _ID; }
			set
			{
				if (value == null)
				{
					throw new Exception("O alojamento tem que ter um ID.");
					return;
				}
				_ID = value;
			}
		}


		public String Tipo
		{
			get { return _tipo; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O alojamento tem que ter um tipo.");
					return;
				}
				_tipo = value;
			}
		}

		public int Preco
		{
			get { return _preco; }
			set
			{
				if (value == null)
				{
					throw new Exception("O alojamento tem que ter um preço.");
					return;
				}
				_preco = value;
			}
		}

		public String Nome
		{
			get { return _nome; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O alojamento tem que ter um nome. ");
					return;
				}
				_nome = value;
			}
		}

		public override String ToString()
		{
			return _nome + " | " + _tipo;
		}

	}
}
