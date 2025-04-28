using Services.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll
{

	public sealed class IdiomaService
	{
		private readonly static IdiomaService _instance = new IdiomaService();

		public static IdiomaService Current
		{
			get
			{
				return _instance;
			}
		}

		private IdiomaService()
		{
			//Implent here the initialization of your singleton
		}


        public string Traducir(string word, string cultura)
		{
			return IdiomaRepository.Current.Traducir(word, cultura);
		}

    }

}
