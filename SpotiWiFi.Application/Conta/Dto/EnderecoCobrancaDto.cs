﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiWiFi.Application.Conta.Dto
{
    public class EnderecoCobrancaDto
    {
        public Guid Id { get; set; }
        public String Endereco { get; set; }
        public String CEP { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Pais { get; set; }
    }
}
