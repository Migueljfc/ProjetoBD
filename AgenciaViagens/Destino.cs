using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaViagens
{
	[Serializable()]
	class Destino
	{

		private string _pais;
		private string _cidade;
		private string _codPostal;


		public String Pais
		{
			get { return _pais; }
			set 
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O destino tem que ter um pais.");
					return;
				}
				_pais = value; 
			}
		}


		public String Cidade
		{
			get { return _cidade; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O destino tem que ter uma cidade.");
					return;
				}
				_cidade = value;
			}
		}

		public String CodPostal
		{
			get { return _codPostal; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O destino tem que ter um codigo postal.");
					return;
				}
				_codPostal = value;
			}
		}

	}
}
