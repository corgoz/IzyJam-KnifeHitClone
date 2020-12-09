# IzyJam-KnifeHitClone

Comentários e desafios da produção:

Eu iniciei o processo jogando a refência o máximo possível criando uma lista básica de tarefas. Como o teste foi um projeto curto, julguei que um esboço geral das tarefas seria ideal, no lugar de gastar tempo detalhando minucias de cada etapa.

Minha primeira preocupação foi ter o jogo básico funcionando sem absolutamente nenhum polimento, apenas cubos e esferas. A partir desse ponto eu alternei entrei criar a UI e lidar com polimento visual para ter uma impressão melhor da direção que o projeto estava tomando. Nessa etapa foi particularmente divertido brincar com as ferramentas de diagramação de UI da Unity, por exemplo fazendo o contator de facas ser responsivo às configurações do level, e experimentar com a física para fazer as facas voarem ao final da fase ou ao colidir com outras facas. 

A etapa seguinte foi cuidar da loja. Pensar uma estrutura de dados que não sobrecarregace o GameManager, nem gerasse muitos problemas de acomplamento, foi um desafio particular. Escolhi uma estrtura com um compoenente independente para a interação com a loja, enquanto o GameManager gerencia apenas a lista de skins e informa o jogador sobre o que foi selecionado. Fiquei bastante satisfeito com o resultado. Foi essa etapa também que cedimentou os assets finais que foram usados para as armas, pela disponibilidade de ícones, além dos prefabs.

Depois que a maoria da loja estava pronta, eu alternei entre refatorar o código e polir mais um pouco a interface, sempre que uma tarefa ficava estagnada. Depois que o projeto ficou em um nível satisfatório, gastei um pouco de tempo produzindo um pouco de conteúdo para o jogo para adicionar variedade. Até esse ponto eu tinha apenas 1 fase e 2 skins, então criei mais 3 novas armas e 3 novas padrões de movimento para as fases para serem sorteados aleatóriamente. 

Para adicioanr uma camada extra de variedade, eu adicionei também facas e moedas no escudo e criei um sistema para sortear o que seria ativado e o que seria desativado em cada fase. Idealmente eu gostaria de ter criado configurações suficientes de fases e alvos para separar categorias de fases fáceis, médias, dificeis e Bosses, sortear dentro das categorias e ter uma progressão de desafio melhor definida no jogo. Entretanto, dado o escopo do teste, eu preferi optar por esta outra solução para adicionar varidade sem precisar criar manualmente tanto conteúdo e sistemas adicionais.

Apenas após todo o resto estar fechado, decidi usar o Unity Ads para algumas recompensas extras, como no jogo de referência. Eu já tinha experiência com pacotes para rastrear eventos no jogo, como Game Analytics, Facebook e AppsFlyer, mas eu ainda não tinha tido a chance de usar um pacote de monetização por vídeos, então esta foi uma boa oportunidade.

O teste foi bastante familiar, já que eu ja tenho prática diária implementando jogos hyper casuai, em decorrência do trabalho. Entretanto, foi gratificante tentar levar o projeto o mais longe possível no prazo. Normalmente existe uma preocupação de parar um desenvolvimento em pontos mais precoces e só progredir caso os testes apresentem resultados favoraveis, e isso é bastante raro.

Tempo gasto:

- Funcionalidades principais, loop de jogo: 3 horas;
- Inteface (Layout e implementação): 3 horas;
- Loja e sistema de skins:  3 horas;
- Unity Ads: 45 min;
- Polimento: 1h 45 min
- Total: 11h 30 min
