using System;
using System.Collections.Generic;
using System.Text;

namespace AgenciaViagens
{
    class Transporte
    {
        private int _ID;
        private string _tipo;
        private string _dataPartida;
        private string _dataChegada;
        private int _preco;
        private string _companhia;
        private int _numPassageiros;

		public Int TransID
		{
			get { return _ID; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O transporte tem que ter um ID.");
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
					throw new Exception("O transporte tem que ter um tipo.");
					return;
				}
				_tipo = value;
			}
		}

		public Int Preco
		{
			get { return _preco; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O transporte tem que ter um preço.");
					return;
				}
				_preco = value;
			}
		}

		public String DataPartida
		{
			get { return _dataPartida; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O transporte tem que ter uma data de partida. ");
					return;
				}
				_dataPartida = value;
			}
		}

		public String DataChegada
		{
			get { return _dataChegada; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O transporte tem que ter uma data de chegada");
					return;
				}
				_dataChegada = value;
			}
		}

		public Int NumPassageiros
		{
			get { return _numPassageiros; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O transporte tem que ter um numero de passageiros.");
					return;
				}
				_numPassageiros = value;
			}
		}


		public String Companhia
		{
			get { return _companhia; }
			set
			{
				if (value == null | String.IsNullOrEmpty(value))
				{
					throw new Exception("O transporte tem que ter uma companhia.");
					return;
				}
				_companhia = value;
			}
		}
	}
}
