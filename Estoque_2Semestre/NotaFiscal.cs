using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_2Semestre
{
    internal class NotaFiscal
    {


    }
}

/*
create table notafiscal(
codnf serial primary key,
codpedido int not nul,
numnf int,
dataemissao date,
natoperacao varchar(15),
xmlimportado varchar(),
constraint rnf01 foreign key(codpedido) references pedido(codpedido) on update cascade,
);

 */