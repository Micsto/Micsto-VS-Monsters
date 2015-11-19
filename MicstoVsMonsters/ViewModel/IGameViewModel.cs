using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicstoVsMonsters.ViewModel
{
	public interface IGameViewModel
	{
		Action<IGameViewModel> Navigate { get; set; }
	}
}
