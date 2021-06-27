using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaViagens
{

	[Serializable()]
	class Viagem
	{
		private int _ID;
		private string _dataInicio;
		private string _dataFim;
		private int _precoTotal;
		private int _numVagas;
		private int _idDest;
		private int _idAloj;
		private int _idTrans;
		private int _idClient;
		private int _pago


		public int ViagemID
		{
			get { return _ID; }
			set { _ID = value; }
		}
		public int Pago
		{
			get { return _pago; }
			set { _pago = value; }
		}

		public int DestID
		{
			get { return _idDest; }
			set { _idDest = value; }
		}
		public int TransID
		{
			get { return _idTrans; }
			set { _idTrans = value; }
		}
		public int AlojID
		{
			get { return _idAloj; }
			set { _idAloj = value; }
		}

		public int ClientID
		{
			get { return _idClient; }
			set { _idClient = value; }
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
		public override String ToString()
		{
			return "ID: " +_ID + " Cliente ID: " +_idClient+ " | Pago:" + _pago;
		}

	}
}
