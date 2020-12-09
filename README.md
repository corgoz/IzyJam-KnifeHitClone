# IzyJam-KnifeHitClone

<b>Comentários e desafios da produção:</b>

  Eu iniciei o processo jogando a referência o máximo possível criando uma lista básica de tarefas. Como o teste foi um projeto curto, julguei que um esboço geral das tarefas seria ideal, no lugar de gastar tempo detalhando minúcias de cada etapa.

  Minha primeira preocupação foi ter o jogo básico funcionando sem absolutamente nenhum polimento, apenas cubos e esferas. A partir desse ponto eu alternei entrei criar a UI e lidar com polimento visual para ter uma impressão melhor da direção que o projeto estava tomando. Nessa etapa foi particularmente divertido brincar com as ferramentas de diagramação de UI da Unity, por exemplo fazendo o contator de facas ser responsivo às configurações do level, e experimentar com a física para fazer as facas voarem ao final da fase ou ao colidir com outras facas.

  A etapa seguinte foi cuidar da loja. Pensar uma estrutura de dados que não sobrecarregasse o GameManager, nem gerasse muitos problemas de acoplamento, foi um desafio particular. Escolhi uma estrutura com um componente independente para a interação com a loja, enquanto o GameManager gerencia apenas a lista de skins e informa o jogador sobre o que foi selecionado. Fiquei bastante satisfeito com o resultado. Foi nessa etapa também que sedimentou os assets finais que foram usados para as armas, pela disponibilidade de ícones, além dos prefabs.

  Depois que a maioria da loja estava pronta, eu alternei entre refatorar o código e polir mais um pouco a interface, sempre que uma tarefa ficava estagnada. Depois que o projeto ficou em um nível satisfatório, gastei um pouco de tempo produzindo um pouco de conteúdo para o jogo para adicionar variedade. Até esse ponto eu tinha apenas 1 fase e 2 skins, então criei mais 3 novas armas e 3 novos padrões de movimento para as fases para serem sorteados aleatoriamente.

  Para adicionar uma camada extra de variedade, eu adicionei também facas e moedas no escudo e criei um sistema para sortear o que seria ativado e o que seria desativado em cada fase. Idealmente eu gostaria de ter criado configurações suficientes de fases e alvos para separar categorias de fases fáceis, médias, difíceis e Bosses, sortear dentro das categorias e ter uma progressão de desafio melhor definida no jogo. Entretanto, dado o escopo do teste, eu preferi optar por esta outra solução para adicionar variedade sem precisar criar manualmente tanto conteúdo e sistemas adicionais.

  Apenas após todo o resto estar fechado, decidi usar o Unity Ads para algumas recompensas extras, como no jogo de referência. Eu já tinha experiência com pacotes para rastrear eventos no jogo, como Game Analytics, Facebook e AppsFlyer, mas eu ainda não tinha tido a chance de usar um pacote de monetização por vídeos, então esta foi uma boa oportunidade.

  O teste foi bastante familiar, já que eu já tenho prática diária implementando jogos hyper casuais, em decorrência do trabalho. Entretanto, foi gratificante tentar levar o projeto o mais longe possível no prazo. Normalmente existe uma preocupação de parar um desenvolvimento em pontos mais precoces e só progredir caso os testes apresentem resultados favoráveis, e isso é bastante raro.

<b>Tempo gasto:</b>

 - Funcionalidades principais, loop de jogo: 3 horas;
 - Interface (Layout e implementação): 3 horas;
 - Loja e sistema de skins: 3 horas;
 - Unity Ads: 45 min;
 - Polimento: 1h 45 min
 - Total: 11h 30 min

