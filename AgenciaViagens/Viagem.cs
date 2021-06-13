using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaViagens
{

	[Serializable()]
	class Viagem
    {
		private String _ID;
		private String _dataInicio;
		private String _dataFim;
		private int _precoTotal;
		private int _numVagas; 


		public String ViagemID
		{
			get { return _ID; }
			set { _ID = value; }
		}


		public String DataInicio
		{
			get { return _dataInicio; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("A Viagem tem que ter uma data de inicio ");
					return;
				}
				_dataInicio = value;
			}
		}

		public String DataFim
		{
			get { return _dataFim; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("A viagem tem que ter uma data de fim");
					return;
				}
				_dataFim = value;
			}
		}

		public int PrecoTotal
		{
			get { return _precoTotal; }
			set { _precoTotal = value; }
		}

		public int NumVagas
		{
			get { return _numVagas; }
			set { _numVagas = value; }
		}

	}
}
