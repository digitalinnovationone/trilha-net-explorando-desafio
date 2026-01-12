🏨 Sistema de Hospedagem – Desafio DIO (.NET / C#)

Projeto desenvolvido como parte do Desafio da Trilha .NET da DIO, com foco na exploração da linguagem C# e na consolidação de conceitos fundamentais como classes, métodos, encapsulamento, listas e regras de negócio.

📚 Sobre o Projeto

Este projeto simula um sistema básico de hospedagem, responsável por realizar reservas em um hotel, aplicando regras de negócio como:

Controle de capacidade da suíte

Cálculo do valor da diária

Aplicação de desconto para longas estadias

O objetivo principal é praticar os conceitos aprendidos nas aulas, transformando teoria em código funcional.

🎯 Objetivos de Aprendizado

Consolidar o uso da linguagem C#

Trabalhar com classes e objetos

Implementar regras de negócio

Utilizar listas (List<T>)

Criar métodos com validações

Lançar exceptions corretamente

🧱 Estrutura do Projeto

O sistema é composto por três classes principais:

👤 Pessoa

Representa o hóspede do hotel.

🛏️ Suíte

Representa a suíte disponível para reserva, contendo:

Tipo da suíte

Capacidade máxima

Valor da diária

📅 Reserva

Responsável por relacionar hóspedes e suíte, além de:

Validar a capacidade da suíte

Calcular a quantidade de hóspedes

Calcular o valor total da diária

Aplicar desconto quando necessário

📐 Regras de Negócio

✔️ Não é permitido reservar uma suíte com capacidade menor do que a quantidade de hóspedes
✔️ O método ObterQuantidadeHospedes() retorna o total de hóspedes da reserva
✔️ O método CalcularValorDiaria() calcula o valor total da estadia
✔️ Reservas com 10 dias ou mais recebem 10% de desconto
✔️ Exceções são lançadas quando regras são violadas

🧮 Cálculo da Diária
Valor total = Dias reservados × Valor da diária

Se dias ≥ 10:
    Aplicar desconto de 10%