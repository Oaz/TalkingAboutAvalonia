using System;
using Avalonia;
using Avalonia.Media;
using TalkingAboutAvalonia.ViewModels.Pages;

namespace TalkingAboutAvalonia.ViewModels;

public static class AllPages
{
  private static Page _example = new ImagePageViewModel("Un exemple", "example.png");
  public static readonly (string Text, int X, int Row)[] NetUi = new[]
  {
    ("Windows Forms (2002)", 0, 0),
    ("ASP.NET Web Forms (2002)", 0, 1),
    ("Gtk# (2004)", 100, 2),
    ("Windows Presentation Foundation (2006)", 100, 3),
    ("Silverlight (2007)", 200, 0),
    ("Moonlight (2009)", 250, 1),
    ("ASP.NET Razor (2010)", 300, 2),
    ("Windows UI (2011)", 350, 0),
    ("AvaloniaUI (2013)", 400, 1),
    ("Xamarin.Forms (2014)", 450, 3),
    ("Blazor (2017)", 500, 2),
    ("Uno (2018)", 550, 1),
    ("MAUI (2020)", 600, 0),
  };
  
  public static Page[] _ = new Page[]
     {
       new TitlePageViewModel("AvaloniaUI : des interfaces graphiques\n(enfin)\nréellement multi-plateformes pour .NET").Notes(@"
Jeu Leaquid en intro.
https://leaquid.mnt.space/

Leaquid va servir de fil rouge tout au long de la présentation
"),

       new TimeLineGameViewModel(NetUi),

      new StackPageViewModel("A better WPF", 100,
        new TextPageViewModel(text: @"The original Avalonia was me playing about seeing how difficult to would be to
reimplement WPF as an OSS project. The answer would have been: ""very difficult"",
but more importantly after a few months of sporadically working on it, I decided I
wasn't having fun. I wanted to improve things where I saw problems, rather than
blindly reimplement WPF warts and all!", fontStyle: FontStyle.Italic),
        new TextPageViewModel(text: "Steven Kirk", textAlignment: TextAlignment.Right)
      ).Notes(@"
https://avaloniaui.net/Blog/10-years-of-avalonia
Article anniversaire 10 ans sur le blog Avalonia
Ça commencé en 2013 comme une ré-écriture de WPF en open source Windows-only
Nom originel : Perspex
Rapidement dévié sur des évolutions pour faire un meilleur WPF
Multiplateforme en 2014 avec Cairo (utilisé à l'époque par Gtk, Mozilla, Mono...)
Aout 2015 : ajout de XAML et 1ère release alpha
Aout 2016 : 0.4.0 - première release nommée Avalonia
"),

       _example.Notes("Écran d'attente des joueurs"),
       new SideBySidePageViewModel(
         new CodePageViewModel("Toujours et encore XAML", "example.xaml_"),
         _example
       ).Notes("Plus ou moins le même XAML que WPF"),

       new SideBySidePageViewModel(
         new CodePageViewModel("Un parfum de CSS", "css.xaml_"),
         _example
       ).Notes(@"
Un concept de styles proche de CSS avec des selectors et des classes"),

      new TitlePageViewModel("Model\nView\nViewModel").Notes(@"
Une appli Avalonia peut s'écrire avec du code-behind
Mais pour tout appli qui n'est pas ultra simple, le MVVM est recommandé
Le template de projet avalonia le plus complet inclus dans .NET est configuré avec MVVM

MVVM est aujourd'hui utilisé dans diverses techno mais il est apparu avec WPF
John Gossman, architecte WPF
"),

      new ImagePageViewModel("Original MVC",
        "original_mvc.gif").Notes(@"
Schema issu d'un des papiers originaux sur le MVC en 1979
Trygve Reenskaug (Norvège) - SmallTalk - Xerox Parc - Alan Kay's Dynabook
https://folk.universitetetioslo.no/trygver/themes/mvc/mvc-index.html

Le but essentiel du MVC est de réduire l'écart entre le modèle mental
de l'utilisateur et le modèle qui existe dans l'ordinateur.
Ce pattern était utilisé aussi bien pour des écrans complets que pour
des morceaux élémentaires (e.g. une scroll bar, un bouton...)
"),

      new SvgPageViewModel("\"Web\" MVC",
        "web_mvc.svg").Notes(@"
Une synthèse des schemas que l'on peut trouver sur le web quand on cherche MVC
L'émergence du web a détourné le MVC de son sens originel
Il n'a plus rien d'un pattern d'interface utilisateur
"),

      new StackPageViewModel("M-V-VM", 100,
        new TitlePageViewModel("Model-View-ViewModel"),
        new SvgPageViewModel("MVVM", "mvvm.svg")
      ).Notes(@"
Le MVVM est plus proche du MVC originel que ne l'est le MVC d'aujourd'hui
On retrouve le mapping entre le modèle mental de l'utilisateur et celui de l'ordinateur
La vue est ce que qui est au contact visuel, tactile et auditif de l'utilisateur
En entrée comme en sortie.
Le VM définit le comportement induit par l'interaction utilisateur.
Les dépendances sont à sens unique :
- la vue connait, agit sur et écoute le VM
- le VM connait, agit sur et écoute le modèle
"),

      new SideBySidePageViewModel(
        new CodePageViewModel("Un MVVM très simple", "ColoredRectangleView.xaml_"),
        new SvgPageViewModel("MVVM", "colored_rectangle_mvvm.svg")
      ).Notes(@"
Exemple: le réservoir qui se remplit d'eau dans le jeu est représenté par un rectangle coloré
Sa taille provient du modèle. Sa couleur est définie par le VM."),

      new SvgPageViewModel("Un pattern Observateur", "mvvm_detailed.svg").Notes(@"
Dans Avalonia comme dans WPF, l'outil avec lequel la vue écoute le VM est sommaire:
une interface avec un seul événement qui indique que la valeur d'une propriété a changé.
L'interaction VM-modèle est laissée au choix de l'application.
Simple. Basique.

Ou pas..."),

      new SvgPageViewModel("Un exemple plus complet", "remote_play_screens.svg").Notes(@"
Dans la réalité, ça peut rapidement devenir compliqué.
Exemple: les écrans permettant de rejoindre une partie.
On saisit le code de la partie. On envoie la demande.
On reçoit la confirmation du maitre de jeu. On attend que la partie commence."),

      new SvgPageViewModel("Un MVVM un peu plus réaliste", "remote_play.svg").Notes(@"
Cela met en jeu plusieurs vues, plusieurs VMs et plusieurs parties du modèle
On constate:
- les vues sont indépendantes et ne se connaissent pas entre elles.
- elles ont chacune un VM
- les VMs représentent la structure de l'interface :
qui est lié à quoi dans le modèle mental de l'utilisateur
- les relations entre VM et modèle sont ce qu'elles ont besoin d'être pour faire correspondre
le modèle de l'utilisateur et celui de l'ordinateur

Organiser un tel ensemble d'objets n'est pas toujours facile à réaliser...
"),

      new SideBySidePageViewModel(
        new CodePageViewModel("ReactiveUI", "mvvm_reactiveui.cs_"),
        new SvgPageViewModel("", "mvvm_reactiveui.svg")
      ).Notes(@"
En pratique on a besoin d'un outillage pour construire les VMs
Avalonia propose ReactiveUI - On peut faire un autre choix mais toute la doc est avec ReactiveUI
ReactiveUI fait automatiquement le lien entre les modifications des propriétés et la levée d'événement
Mais il permet surtout d'orchestrer déclarativement le comportement des VMs.
Ici par exemple, il fait la validation du code pour rejoindre une partie à chaque fois que celui-ci change.

La structure When/Subscribe est quelque chose de classique...
"),

      new ImagePageViewModel("ReactiveX", "reactivex.png").Notes(@"
https://reactivex.io/
ReactiveX = Reactive Extensions
Bibliothèque qui permet de mettre en oeuvre un pattern observateur en décrivant déclarativement
les comportements sur chaque observation.
Pour cela, on traite les observations comme des enumerations dans le temps.
La richesse des opérateurs disponibles est encore plus grande que celle existante sur les enumerables

La bibliothèque existe sur de nombreuses plateformes.
La version orignelle est en .NET. Sortie par Microsoft en 2011.
"),
      new SvgPageViewModel("ReactiveUI utilise ReactiveX", "mvvm_reactiveui2.svg"),
      new SvgPageViewModel("ReactiveX Everywhere", "mvvm_reactiveui3.svg").Notes(@"
Tout comme le pattern observateur, ReactiveX n'a rien de spécifique aux interfaces graphiques.
On peut utiliser ReactiveX entre les VMs et le modèle.
C'est ce qui est fait dans le jeu.
"),

      new SideBySidePageViewModel(
        new CodePageViewModel("ReactiveX dans le Model", "mvvm_reactivex.cs_"),
        new SvgPageViewModel("", "mvvm_reactiveui3.svg")
      ).Notes(@"
Exemple: afficher le joueur courant dans une couleur différente des autres joueurs.

On peut jouer à Leaquid entièrement en local et passer d'un joueur à l'autre
Updates = changement de joueur courant
Scan = ~Aggregate + renvoie toutes les agrégations intermédiaires sous forme d'observable

L'agrégation sur les updates permet de construire un observable de paires (joueur précédent, joueur courant)
On peut ainsi directement redonner une couleur neutre au joueur précédent et changer la couleur du joueur courant
"),

      new SideBySidePageViewModel(
        new ImagePageViewModel("DynamicData dans le Model", "mvvm_dynamicdata.png"),
        new SvgPageViewModel("", "mvvm_dynamicdata.svg")
      ).Notes(@"
Il y a des cas où ReactiveX ne suffit pas.
Exemple : 
dans le modèle, les gouttes d'eau de l'inondation sont une collection de coordonnées.
Quand le temps passe, les gouttes tombent.
Certaines coordonnées sont ajoutées, d'autres sont enlevées.
Si le modèle se contente d'exposer la liste complète et ne fournit pas ces informations d'ajout/retrait,
il complique potentiellement le travail de ceux qui l'observent.

ReactiveX n'a pas d'outils satisfaisant pour observer des évolutions dans une collection.
On utilise DynamicData, une extension aux reactive extensions
DynamicData est d'ailleurs aussi utilisé par ReactiveUI
"),

      new SideBySidePageViewModel(
        new CodePageViewModel("DynamicData dans le Model", "mvvm_dynamicdata.cs_"),
        new StackPageViewModel("", 0,
          new ImagePageViewModel("DynamicData dans le Model", "mvvm_dynamicdata.png"),
          new SvgPageViewModel("", "mvvm_dynamicdata.svg")
        )
      ).Notes(@"
Dans le modèle, on utilise un SourceCache de DynamicData sur lequel on peut faire des ajouts/retraits
qui vont être notifiés tels quels dans la relation observable/observateur
Dans le VM, DynamicData reconstitue automatiquement la liste complète
et la transforme en image bitmap.

Dans le cas présent, le VM n'aurait pas vraiment besoin de connaitre les ajouts/retraits
Mais il n'est pas le seul à utiliser le modèle
Le jeu est en réseau.
Le calcul du comportement des gouttes d'eau est centralisé
et son affichage est déporté chez les participants.
Si on veut utiliser le réseau de manière optimale,
l'équivalent du VM dans l'encodage de données réseau observe aussi le modèle
et a besoin des informations d'ajout/retrait 

Il faut garder à l'esprit que le modèle n'est pas un élément spécifique à l'interface utilisateur.
Le modèle n'est pas une notion 'front-end', pour parler avec des termes actuels.
C'est le rôle du VM d'adapter à l'interface utilisateur un modèle utilisé par tous le reste de l'application"),

       new ImagePageViewModel("Hexagonal architecture",
         "Hexagonal-architecture-complex-example.gif").Notes(@"
https://alistair.cockburn.us/hexagonal-architecture/
Schema dans l'article de Alistair Cockburn qui introduit la notion d'architecture hexagonale
Dans une architecture hexagonale, le coeur métier de l'application, donc le *modèle* est au centre
Il ne dépend de rien. Tout le monde dépend de lui.
Les entrée/sorties (database, réseau, interfaces graphiques...)
sont des plugins qui viennent s'insérer dans le coeur
Et ces plugins sont tous indépendants.
"),
       
       new SvgPageViewModel("ViewModel = adapter", "hexagonal.svg").Notes(@"
Le jeu Leaquid est construit avec une architecture hexagonale
Un projet C# nommé Core contient les règles de fonctionnement du jeu
hors de toute considération graphique ou réseau

La communication réseau MQTT est dans un projet C# nommé Network qui dépend de Core
L'interface utilisateur, les vues et les VMs Avalonia sont dans un projet C# nommé UserInterface
Au sens d'une architecture hexagonale, les VMs sont donc des adaptateurs.
Ils permettent d'interfacer une techno d'interface graphique avec le coeur du métier.
Une projet C# nommé App relie l'ensemble pour créer le coeur et y injecter les divers plugins

On notera qu'il n'y a aucune notion de front-end/back-end dans cette architecture.
La séparation front-end back-end est un artifice qui a été introduit par le web.
Elle peut être utile dans un contexte de déploiement web mais n'a strictement aucune utilité architecturale.

Cela vaut le coup d'être répété :
une séparation front-end/back-end n'a aucune utilité dans l'architecture d'une application logicielle
c'est un détail de déploiement
"),
       
       new SvgPageViewModel("Le multi-plateforme est un détail", "hexagonal2.svg").Notes(@"
Avec Avalonia, le multiplateforme aussi est ce qu'il devrait toujours être : un détail.
Il ne nécessite qu'un mini projet par plateforme pour l'initialiser
Pour tout le reste de l'application, le code est strictement identique

On a joué avec un hôte desktop sur mon PC et chacun des joueurs avec un browser web.
On aurait tout aussi bien pu avoir l'hôte sur un browser ou un android
et des joueurs sur toutes les plateformes.

Le multiplateforme devient un détail
au point où on n'a même plus besoin de penser en terme back et front.
Tout le monde joue en attaque et en défense.
"),
       
       new SideBySidePageViewModel(
         new ImagePageViewModel("Le multi-plateforme est quasiment gratuit", "projects.png"),
         new SvgPageViewModel("", "hexagonal_sizes.svg")
       ).Notes(@"
En regardant le nombre d'instruction de chaque projet (au sens code coverage),
on mesure l'importance respective de chaque partie
La gestion du multiplateforme est réellement un détail.
99% du code est commun à toutes les plateformes"),
       
       new SideBySidePageViewModel(
         new CodePageViewModel("Desktop", "desktop.cs_"),
         new SvgPageViewModel("", "hexagonal_sizes.svg")
       ).Notes(@"
L'intégralité du code de l'application Desktop, Windows ou Linux
On indique d'utiliser TCP pour le MQTT
L'ouverture de pages web externes se fait par 'shell execute'
Le cadencement du jeu est donné par un observable qui produit un élément à intervalle régulier prédéfini

Ces 3 extensions à la définition d'une application Avalonia sont spécifiques à notre application
Ils sont déclarés au niveau du projet App
Ils sont utilisés par chacun des projets plateforme"),
       
       new SideBySidePageViewModel(
         new CodePageViewModel("Desktop", "browser.cs_"),
         new SvgPageViewModel("", "hexagonal_sizes.svg")
       ).Notes(@"
C'est différent sur la plateforme Browser, donc Web Assembly
Les threads ne sont pas disponibles au niveau où ils le sont dans une application desktop
Le cadencement doit utiliser une autre technique.
Ici, on vient s'insérer dans la boucle principale d'événements d'Avalonia.
Par ailleurs, la communication MQTT ne peut se faire qu'en web sockets.
L'ouverture de page web externes est un interop qui appelle le 'window.open' de javascript

Le support multiplateforme se limite à cela :
des ajustements sur quelques détails technologiques
"),

       new ImagePageViewModel("MAUI vs Avalonia",
         "maui-avalonia.png").Notes(@"
En fait, avec Avalonia, le support des plateformes est quasi identique à ce qui se fait ailleurs en .NET
Cette image est tirée du blog Avalonia
https://avaloniaui.net/Blog/avalonia-the-premier-choice-for-net-developers-targeting-linux
En comparant avec MAUI, on retrouve des usages similaires pour les runtimes .NET Core et Mono
La grosse différence vient du rendering.
MAUI n'est qu'une couche d'abstraction au dessus de diverses techno spécifiques à chaque plateforme

Avalonia effectue son propre rendering avec Skia de manière identique
sur toutes les plateformes disponibles en .NET
Y compris Linux que MAUI ne supporte pas
Skia est une bibliothèque de rendu 2D utilisée à peu près partout aujourd'hui,
notamment par Chrome et Firefox

En fait, il suffit qu'une plateforme soit disponible pour .NET
et Avalonia est quasiment disponible automatiquement
Pas besoin de bibliothèque graphique dédiée à la plateforme.
"),

       new ImagePageViewModel("Un arbre logique des vues", "logical_tree_views.png").Notes(@"
Sous le capot, Avalonia a un arbre logique des vues où l'on retrouve le contenu de nos fichiers XAML.
On a parlé des vues qui sont indépendantes et qui ne connaissent que leur VM, pas les autres vues.
Les ContentControl sont les frontières entre les vues.
Ils permettent de dire :
'je veux mettre ici la vue correspondant à tel VM qui est une propriété de mon VM'

Exemple:
HomeVM a 2 propriétés OptionsVM et UserChoicesVM
On retrouve cette relation dans l'arbre des vues mais avec les ContentControl comme charnière
Les ContentControl permettent l'indépendance des vues les unes par rapport aux autres"),
       
       new SideBySidePageViewModel(
         new ImagePageViewModel("Les détails sont dans l'arbre visuel", "logical_tree.png"),
         new ImagePageViewModel("", "visual_tree.png")
       ).Notes(@"
A partir de l'arbre logique, Avalonia déduit un arbre visuel
Il contient la totalité des éléments graphiques utilisés pour le rendering

Un parallèle avec le DOM utilisé par les navigateurs web serait :
- l'arbre logique est un arbre de web components
- l'arbre visuel contient l'ensemble des shadow dom de chaque composant
"),

       new SideBySidePageViewModel(
         new ImagePageViewModel("La scène n'est qu'une liste d'éléments bien positionnés", "stage.png"),
         new CodePageViewModel("", "stage_view.xaml_")
       ).Notes(@"
L'arbre logique permet de facilement composer les vues sans a priori sur leurs contenus respectifs

Exemple:
Pour l'affichage de la scène dans le jeu, on utilise un ItemsControl
C'est un élement graphique qui permet d'afficher une liste d'éléments
Il est utilisé par exemple pour une ListBox
"),

       new SideBySidePageViewModel(
         new CodePageViewModel("La scène n'est qu'une liste d'éléments bien positionnés", "stage_viewmodel.cs_"),
         new CodePageViewModel("", "stage_view.xaml_")
       ).Notes(@"
Mais ici le panel dans lequel sont les éléments de la liste est un Canvas
Le canvas permet de positionner n'importe quelle vue à une position (X,Y)
Les 'Actors' sont les divers élements du jeu (joueurs, décor, remplissage...) présents dans cette liste

Autre exemple de panel avec des vues dans un graphique vectoriel
-> montrer l'exemple des jeux dans le graphe
"),

       new TitlePageViewModel("Le web est un formidable\nmécanisme de deploiement").Notes(@"
Ça sera ma phrase conclusion
Le web a cette magie où chaque click sur un lien permet de naviguer vers un monde différent
C'est le mécanisme de déploiement ultime
 
Quel rapport avec les interfaces graphique multi-plateformes ?
Le web n'est qu'un formidable mécanisme de deploiement. Rien d'autre.
Quand on pense UI multiplateforme, on se dit souvent, je vais faire une 'UI web' car c'est dispo partout.
Les UI webs sont devenues omnipotentes grace à la force du déploiement simplifié
et aux innombrables outils qui ont été développés pour masquer les faiblesses du DOM

Avalonia offre une solution beaucoup plus simple et beaucoup moins gourmande en ressources
Avalonia consomme beaucoup moins de CPU qu'un affichage DOM

Avalonia n'est pas unique. Qt et Flutter ont des approches similaires
Mais ils ne sont pas vraiment utilisable dans le monde .NET

Les UI web ont acquis un tel monopole qu'il est malheureusement difficile de les déloger
Mais ça vaut parfois le coup de ne pas y plonger sans envisager des alternatives comme Avalonia.
"),

       new SideBySidePageViewModel(
         new TitlePageViewModel("https://github.com/Oaz/Leaquid"),
         new QrPageViewModel("https://github.com/Oaz/Leaquid", Brushes.Black)
       ).Notes("Le code source du jeu Leaquid"),

       new SideBySidePageViewModel(
         new StackPageViewModel("Choose your slides", 0,
           new SvgPageViewModel("", "blue_pill.svg"),
           new QrPageViewModel("http://slides.azeau.com/20240429-about-avalonia/", Brushes.Blue)
         ),
         new StackPageViewModel("", 0,
           new SvgPageViewModel("", "red_pill.svg"),
           new QrPageViewModel("https://github.com/Oaz/TalkingAboutAvalonia", Brushes.Red)
         )
       ).Notes(@"
Les slides sont disponibles en 2 version
- pilule bleue : les slides et rien de plus
- pilule rouge : on n'a pas les slides que l'on attendait mais on découvre de nouvelles perspectives")
     };

}