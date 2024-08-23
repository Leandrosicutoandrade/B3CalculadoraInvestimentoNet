# Projeto de Calculo de Investimento CDB

## Visão Geral

Este projeto consiste em uma solução do Visual Studio que inclui dois projetos principais:

	- Projeto Web: Desenvolvido com Angular CLI.
	- Web API: Desenvolvida em .NET Framework 4.7.2.

## Estrutura da Solução

	- Calcular.Investimento.WebApi
	- Calcular.Investimento.Domain
	- Calcular.Investimento.Core
	- Calcular.Investimento.Test

	### Requisitos

		- Visual Studio (versão 2019 ou superior recomendada)
		- .NET Framework 4.7.2
		- Angular CLI
		- Node.js 

## Instruções para Execução

	### Executar a Web API

		1. Abrir a Solução no Visual Studio:**
		2. Compilar e Executar a Web API:
		3. Verificar a API:
			- A Web API estará disponível em `http://localhost:[Porta]/api/calculo`.

	### Executar o Projeto Web (Angular)

		1. Abrir o Terminal:
			- Navegue até a pasta do projeto Web no terminal.
		2. Instalar Dependências:
		3. Compilar e Executar o Projeto Web:
			- A aplicação estará disponível em `http://localhost:4200`.

## Testes da Web API

	### Testes para `CalculoController`

		A classe `CalculoControllerTests` contém dois testes principais para o controlador `CalculoController`:

		1. **`Get_ComParametros_ValoresInvalidos_DeveRetornarBadRequest`**
			- Testa o comportamento do método `Get` quando são fornecidos parâmetros inválidos.
			- Verifica se o resultado é um `BadRequestErrorMessageResult`.

		2. **`Get_ComParametros_ValoresValidos_DeveRetornarResultadoCalculo`**
			- Testa o comportamento do método `Get` quando são fornecidos parâmetros válidos.
			- Verifica se o resultado é um `OkNegotiatedContentResult` e se o conteúdo retornado corresponde ao esperado.


		#### Instruções para Execução dos Testes

			1. **Configurar o Projeto de Teste:**
				- Certifique-se de que o projeto `Calcular.Investimento.Test` está configurado corretamente no Visual Studio.
				- Verifique se as bibliotecas `NUnit` e `Moq` estão instaladas e referenciadas.

			2. **Executar os Testes:**
				- Abra o Visual Studio e carregue a solução que contém o projeto de testes.
				- No menu, vá até `Test` > `Run All Tests` para executar todos os testes do projeto.
				- Você também pode usar o Test Explorer para executar testes específicos.

		#### Descrição dos Testes

			#### Teste: `Get_ComParametros_ValoresInvalidos_DeveRetornarBadRequest`

				- **Objetivo:** Verificar se o método `Get` retorna um `BadRequestErrorMessageResult` quando os parâmetros fornecidos são inválidos (0, 0).
				- **Configuração:**
					- Chama o método `Get` com `valorInicial` e `prazoMes` ambos iguais a 0.
				- **Resultado Esperado:** O método deve retornar um `BadRequestErrorMessageResult`.

			#### Teste: `Get_ComParametros_ValoresValidos_DeveRetornarResultadoCalculo`

				- **Objetivo:** Verificar se o método `Get` retorna um resultado de cálculo correto quando os parâmetros são válidos.
				- **Configuração:**
					- Mock de `ICdbApplication` configurado para retornar uma resposta esperada ao método `CalcularInvestimento`.
					- Chama o método `Get` com `valorInicial` = 1000 e `prazoMes` = 12.
				- **Resultado Esperado:** O método deve retornar um `OkNegotiatedContentResult` com o `ValorLiquido` correspondente ao valor esperado.


	### Testes para `CdbApplication`

		A classe `CdbApplicationTests` contém dois testes principais para o método `CalcularInvestimento` da classe `CdbApplication`:

		1. **`CalcularInvestimento_ValoresValidos_DeveRetornarResultadoEsperado`**
			- Verifica se o método `CalcularInvestimento` retorna o resultado esperado quando são fornecidos parâmetros válidos.
			- Confirma que o valor bruto, o valor líquido e o imposto calculados estão corretos.

		2. **`CalcularInvestimento_ValoresValidos_NaoDeveRetornarResultadoEsperado`**
			- Verifica se o método `CalcularInvestimento` não retorna resultados incorretos quando os parâmetros são válidos.
			- Garante que os valores calculados não correspondem a resultados errôneos.


		#### Instruções para Execução dos Testes

			1. **Configurar o Projeto de Teste:**
				- Certifique-se de que o projeto `Calcular.Investimento.Test` está configurado corretamente no Visual Studio.
				- Verifique se as bibliotecas `NUnit` e `Moq` estão instaladas e referenciadas.

			2. **Executar os Testes:**
				- Abra o Visual Studio e carregue a solução que contém o projeto de testes.
				- No menu, vá até `Test` > `Run All Tests` para executar todos os testes do projeto.
				- Você também pode usar o Test Explorer para executar testes específicos.

		#### Descrição dos Testes

			#### Teste: `CalcularInvestimento_ValoresValidos_DeveRetornarResultadoEsperado`

				- **Objetivo:** Verificar se o método `CalcularInvestimento` retorna os resultados corretos quando os parâmetros fornecidos são válidos.
				- **Configuração:**
					- Mock de `ICdbService` e `IImpostoService` configurado para retornar valores esperados.
					- Chama o método `CalcularInvestimento` com `ValorInicial` = 1000 e `PrazoMeses` = 12.
				- **Resultado Esperado:**
					- `ValorBruto` deve ser igual ao valor final esperado.
					- `ValorLiquido` deve ser igual ao valor final esperado menos o imposto esperado.
					- `ValorImposto` deve ser igual ao imposto esperado.

			#### Teste: `CalcularInvestimento_ValoresValidos_NaoDeveRetornarResultadoEsperado`

				- **Objetivo:** Verificar se o método `CalcularInvestimento` não retorna valores incorretos quando os parâmetros são válidos.
				- **Configuração:**
					- Mock de `ICdbService` e `IImpostoService` configurado para retornar valores esperados.
				- Chama o método `CalcularInvestimento` com `ValorInicial` = 1000 e `PrazoMeses` = 12.
				- **Resultado Esperado:**
					- `ValorBruto` não deve ser igual ao valor final esperado menos 1.
					- `ValorLiquido` não deve ser igual ao valor final esperado menos imposto esperado menos 1.
					- `ValorImposto` não deve ser igual ao imposto esperado menos 1.


	### Testes para `CdbService`

		A classe `CdbServiceTests` contém quatro testes principais para o método `CalcularValorFinal` e o método `CalcularValorFinalPorMeses` da classe `CdbService`:

		1. **`CalcularValorFinal_ValoresValidos_DeveRetornarResultadoEsperado`**
		   - Verifica se o método `CalcularValorFinal` retorna o resultado esperado para valores válidos.

		2. **`CalcularValorFinalPorMeses_12Meses_DeveRetornarValorFinalCorreto`**
		   - Verifica se o método `CalcularValorFinalPorMeses` retorna o valor final correto quando o número de meses é 12.

		3. **`CalcularValorFinalPorMeses_MesesZero_DeveRetornarValorInicial`**
		   - Verifica se o método `CalcularValorFinalPorMeses` retorna o valor inicial quando o número de meses é 0.

		4. **`CalcularValorFinalPorMeses_ValoresNegativos_DeveRetornarValorCorreto`**
		   - Verifica se o método `CalcularValorFinalPorMeses` retorna o valor final correto quando o valor inicial é negativo.


		#### Instruções para Execução dos Testes

			1. **Configurar o Projeto de Teste:**
			   - Certifique-se de que o projeto `Calcular.Investimento.Test` está configurado corretamente no Visual Studio.
			   - Verifique se o NUnit está instalado e referenciado no projeto.

			2. **Executar os Testes:**
			   - Abra o Visual Studio e carregue a solução que contém o projeto de testes.
			   - No menu, vá até `Test` > `Run All Tests` para executar todos os testes do projeto.
			   - Você também pode usar o Test Explorer para executar testes específicos.

		#### Descrição dos Testes

			#### Teste: `CalcularValorFinal_ValoresValidos_DeveRetornarResultadoEsperado`

				- **Objetivo:** Verificar se o método `CalcularValorFinal` retorna o resultado correto quando os valores fornecidos são válidos.
				- **Configuração:**
					- Configura o `CdbService` com parâmetros válidos e calcula o valor final.
					- Compara o resultado com o valor esperado retornado pela mesma função.
				- **Resultado Esperado:** O resultado retornado deve ser igual ao valor esperado.

			#### Teste: `CalcularValorFinalPorMeses_12Meses_DeveRetornarValorFinalCorreto`

				- **Objetivo:** Verificar se o método `CalcularValorFinalPorMeses` calcula corretamente o valor final após 12 meses.
				- **Configuração:**
					- Configura o `CdbService` com 12 meses e calcula o valor final.
					- Compara o resultado com o valor esperado calculado manualmente.
				- **Resultado Esperado:** O valor final retornado deve ser igual ao valor esperado após 12 meses.

			#### Teste: `CalcularValorFinalPorMeses_MesesZero_DeveRetornarValorInicial`

				- **Objetivo:** Verificar se o método `CalcularValorFinalPorMeses` retorna o valor inicial quando o número de meses é 0.
				- **Configuração:**
					- Configura o `CdbService` com 0 meses e calcula o valor final.
				- **Resultado Esperado:** O resultado deve ser igual ao valor inicial fornecido.

			#### Teste: `CalcularValorFinalPorMeses_ValoresNegativos_DeveRetornarValorCorreto`

				- **Objetivo:** Verificar se o método `CalcularValorFinalPorMeses` calcula corretamente o valor final quando o valor inicial é negativo.
				- **Configuração:**
					- Configura o `CdbService` com um valor inicial negativo e calcula o valor final.
					- Compara o resultado com o valor esperado calculado manualmente.
				- **Resultado Esperado:** O valor final retornado deve ser igual ao valor esperado para valores negativos.



	### Testes para `ImpostoService`

		A classe `ImpostoServiceTests` contém cinco testes principais para o método `CalcularImposto` da classe `ImpostoService`:

		1. **`CalcularImposto_MesesMenorOuIgualA6_DeveAplicarAliquotaDe225`**
		   - Verifica se a alíquota de imposto é corretamente aplicada quando o número de meses é menor ou igual a 6.

		2. **`CalcularImposto_MesesEntre7e12_DeveAplicarAliquotaDe20`**
		   - Verifica se a alíquota de imposto é corretamente aplicada quando o número de meses está entre 7 e 12.

		3. **`CalcularImposto_MesesEntre13e24_DeveAplicarAliquotaDe175`**
		   - Verifica se a alíquota de imposto é corretamente aplicada quando o número de meses está entre 13 e 24.

		4. **`CalcularImposto_MesesMaiorQue24_DeveAplicarAliquotaDe15`**
		   - Verifica se a alíquota de imposto é corretamente aplicada quando o número de meses é maior que 24.

		5. **`CalcularImposto_RendimentoZero_DeveRetornarZero`**
		   - Verifica se o imposto calculado é zero quando o rendimento é zero, independentemente do número de meses.


		#### Instruções para Execução dos Testes

			1. **Configurar o Projeto de Teste:**
			   - Certifique-se de que o projeto `Calcular.Investimento.Test` está configurado corretamente no Visual Studio.
			   - Verifique se o NUnit está instalado e referenciado no projeto.

			2. **Executar os Testes:**
			   - Abra o Visual Studio e carregue a solução que contém o projeto de testes.
			   - No menu, vá até `Test` > `Run All Tests` para executar todos os testes do projeto.
			   - Você também pode usar o Test Explorer para executar testes específicos.

		#### Descrição dos Testes

			##### Teste: `CalcularImposto_MesesMenorOuIgualA6_DeveAplicarAliquotaDe225`

				- **Objetivo:** Verificar se a alíquota de 22.5% é aplicada corretamente para períodos de até 6 meses.
				- **Configuração:**
					- Configura o `ImpostoService` com um rendimento de 1000 e meses igual a 6.
					- Calcula o imposto esperado e compara com o resultado retornado.
				- **Resultado Esperado:** O imposto calculado deve ser 22.5% do rendimento.

			##### Teste: `CalcularImposto_MesesEntre7e12_DeveAplicarAliquotaDe20`

				- **Objetivo:** Verificar se a alíquota de 20% é aplicada corretamente para períodos entre 7 e 12 meses.
				- **Configuração:**
					- Configura o `ImpostoService` com um rendimento de 1000 e meses igual a 12.
					- Calcula o imposto esperado e compara com o resultado retornado.
				- **Resultado Esperado:** O imposto calculado deve ser 20% do rendimento.

			##### Teste: `CalcularImposto_MesesEntre13e24_DeveAplicarAliquotaDe175`

				- **Objetivo:** Verificar se a alíquota de 17.5% é aplicada corretamente para períodos entre 13 e 24 meses.
				- **Configuração:**
					- Configura o `ImpostoService` com um rendimento de 1000 e meses igual a 24.
					- Calcula o imposto esperado e compara com o resultado retornado.
				- **Resultado Esperado:** O imposto calculado deve ser 17.5% do rendimento.

			##### Teste: `CalcularImposto_MesesMaiorQue24_DeveAplicarAliquotaDe15`

				- **Objetivo:** Verificar se a alíquota de 15% é aplicada corretamente para períodos maiores que 24 meses.
				- **Configuração:**
					- Configura o `ImpostoService` com um rendimento de 1000 e meses igual a 25.
					- Calcula o imposto esperado e compara com o resultado retornado.
				- **Resultado Esperado:** O imposto calculado deve ser 15% do rendimento.

			##### Teste: `CalcularImposto_RendimentoZero_DeveRetornarZero`

				- **Objetivo:** Verificar se o imposto calculado é zero quando o rendimento é zero, independentemente do número de meses.
				- **Configuração:**
					- Configura o `ImpostoService` com um rendimento de 0 e meses igual a 10.
				- **Resultado Esperado:** O imposto calculado deve ser zero.

----------------------

Este arquivo `README.md` fornece uma visão geral clara sobre como executar os testes, quais são os objetivos de cada teste e como o ambiente deve ser configurado para garantir que os testes funcionem corretamente.

