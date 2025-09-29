using Kingmaker.Localization;
using Kingmaker.Localization.Shared;

namespace AutoMountNext.Strings
{
	internal class ModStrings
	{
		public static readonly LocalizedString ModDesc = Utilities.CreateStringAll("dpautomount-desc",
			enGB: "Adds a hotkey to mount/dismount pets and automounts when entering an area. Compatible with Tabletop Tweak's Undersized Mount feat.",
			deDE: "Fügt einen Hotkey zum Auf-und Absteigen von Haustieren und zum automatischen Aufsteigen beim Betreten eines Bereichs hinzu. Kompatibel mit Tabletop Tweak's Unterdimensionierter Anhängungs-Fähigkeit.",
			esES: "Añade una tecla de acceso rápido para montar y desmontar mascotas y se monta automáticamente al entrar en una zona. Compatible con la función de Montura Subdimensionada de Tabletop Tweak.",
			frFR: "Ajoute un raccourci clavier pour monter/descendre des familiers et des montures automatiques en entrant dans une zone. Compatible avec la fonctionnalité Monture sous-dimensionnée de Tabletop Tweak.",
			itIT: "Aggiunge un tasto di scelta rapida per montare/smontare da animali domestici e per la monta automatica quando si entra in un'area. Compatibile con il talento Montatura sottodimensionata di Tabletop Tweak.",
			plPL: "Dodaje klawisz skrótu do wsiadania/zsiadania ze zwierząt i automatycznego wsiadania po wejściu na teren. Zgodny z funkcją Undersized Mount w Tabletop Tweak.",
			ptBR: "Adiciona uma tecla de atalho para montar/desmontar mascotes e montarias automáticas ao entrar em uma área. Compatível com o recurso de montaria subdimensionada do Tabletop Tweak.",
			ruRU: "Добавляет горячую клавишу для седла/спешивания питомцев и автосесть при входе в зону. Совместимо с Tabletop Tweak's Undersized Mount feat.",
			zhCN: "添加热键，用于在进入区域时骑乘/下马宠物并自动骑乘。与 Tabletop Tweak 的“小坐骑”专长兼容。"
		);

		public static readonly LocalizedString HeaderHotkeysDesc = Utilities.CreateStringAll("dpautomount-headerhotkeys-desc",
			enGB: "Hotkeys",
			deDE: "Schnelltasten",
			esES: "Teclas de acceso rápido",
			frFR: "Raccourcis clavier",
			itIT: "Tasti di scelta rapida",
			plPL: "Skróty klawiszowe",
			ptBR: "Teclas de atalho",
			ruRU: "Горячие клавиши",
			zhCN: "热键"
		);

		public static readonly LocalizedString HeaderWhitelistDesc = Utilities.CreateStringAll("dpautomount-headerwhitelist-desc",
			enGB: "Character Whitelist",
			deDE: "Charakter-Weißliste",
			esES: "Lista blanca de caracteres",
			frFR: "Liste blanche des caractères",
			itIT: "Elenco bianco dei caratteri",
			plPL: "Biała lista znaków",
			ptBR: "Lista branca de caracteres",
			ruRU: "Белый список персонажей",
			zhCN: "字符白名单"
		);

		public static readonly LocalizedString ToggleMountOnEnterDesc = Utilities.CreateStringAll("dpautomount-areaentermount-desc",
			enGB: "Mount On Entering Area",
			deDE: "Montieren beim Betreten eines Bereichs",
			esES: "Monte al entrar al área",
			frFR: "Monter sur la zone d'entrée",
			itIT: "Montare all'ingresso dell'area",
			plPL: "Zamontuj na wejściu",
			ptBR: "Montar ao entrar na área",
			ruRU: "Крепление на входе в зону",
			zhCN: "进入区域时安装"
		);

		public static readonly LocalizedString ToggleMountOnEnterDescLong = Utilities.CreateStringAll("dpautomount-areaentermount-desc-long",
			enGB: "Automatically mounts all whitelisted party members when entering/loading a new area.",
			deDE: "Montieren alle in der Weißliste aufgeführten Parteimitglieder automatisch beim Betreten/Laden eines neuen Bereichs an.",
			esES: "Monta automáticamente a todos los miembros del grupo incluidos en la lista blanca al ingresar o cargar una nueva área.",
			frFR: "Monte automatiquement tous les membres du groupe sur liste blanche lors de l'entrée/du chargement d'une nouvelle zone.",
			itIT: "Monta automaticamente tutti i membri del gruppo nella whitelist quando si entra/carica una nuova area.",
			plPL: "Automatycznie wsiada na wszystkich członków drużyny z białej listy podczas wchodzenia na nowy obszar lub jego wczytywania.",
			ptBR: "Monta automaticamente todos os membros do grupo na lista de permissões ao entrar/carregar uma nova área.",
			ruRU: "Автоматически садит всех членов группы из белого списка при входе/загрузке новой области.",
			zhCN: "进入/加载新区域时自动安装所有白名单队员。"
		);

		public static readonly LocalizedString ToggleRideAivuDesc = Utilities.CreateStringAll("dpautomount-rideaivu-desc",
			enGB: "Prefer Aivu As Primary Mount",
			deDE: "Bevorzugen Sie Aivu als primäres Reittier",
			esES: "Prefiero a Aivu como montura principal",
			frFR: "Préférez Aivu comme monture principale",
			itIT: "Preferisci Aivu come cavalcatura primaria",
			plPL: "Preferuj Aivu jako wierzchowiec podstawowy",
			ptBR: "Prefira Aivu como montaria primária",
			ruRU: "Предпочитаю Айву как основное ездовое животное",
			zhCN: "首选 Aivu 作为主要坐骑"
		);

		public static readonly LocalizedString ToggleRideAivuDescLong = Utilities.CreateStringAll("dpautomount-rideaivu-desc-long",
			enGB: "When enabled, an Azata character will mount Aivu instead of their class pet (if they have one) when using the AutoMount hotkey and the automatic Mount On Entering Area.\n\n<b>N.B.</b> This will only take effect for characters that have Aivu and another rideable pet simultaneously. It should also work for companions taking Azata via ToyBox, etc. if they have a second pet.\n\nNote that if Aivu is currently too small or otherwise unsuitable to mount (incapacitated, dead, etc.), the character will attempt to mount their class pet instead.",
			deDE: "Wenn aktiviert, reitet ein Azata-Charakter Aivu anstelle seines Klassentiers (falls vorhanden), wenn er den Hotkey „AutoMount“ und die automatische „Reiten beim Betreten des Gebiets“ verwendet.\n\n<b>Hinweis:</b> Dies gilt nur für Charaktere, die Aivu und ein anderes reitbares Tier gleichzeitig haben. Es sollte auch für Gefährten funktionieren, die Azata per Toybox usw. mitnehmen, sofern sie ein zweites Tier haben.\n\nBeachten Sie: Wenn Aivu zu klein oder aus anderen Gründen (unfähig, tot usw.) zum Reiten ungeeignet ist, versucht der Charakter stattdessen, sein Klassentier zu besteigen.",
			esES: "Al habilitar esta función, un personaje Azata montará a Aivu en lugar de a su mascota de clase (si la tiene) al usar la tecla de acceso rápido Montar automáticamente y la opción Montar al entrar en el área.\n\n<b>Nota:</b> Esto solo funcionará para personajes que tengan a Aivu y otra mascota montable simultáneamente. También debería funcionar para compañeros que lleven a Azata a través de ToyBox, etc., si tienen una segunda mascota.\n\nTen en cuenta que si Aivu es demasiado pequeño o no es apto para montar (incapacitado, muerto, etc.), el personaje intentará montar a su mascota de clase.",
			frFR: "Lorsque cette option est activée, un personnage Azata chevauchera Aivu au lieu de son familier de classe (s'il en possède un) en utilisant le raccourci Monture automatique et la fonction Monter automatiquement à l'entrée de la zone.\n\n<b>N.B.</b> Cette option ne s'applique qu'aux personnages possédant Aivu et un autre familier à monter simultanément. Elle devrait également fonctionner pour les compagnons qui emmènent Azata via ToyBox, etc., s'ils possèdent un deuxième familier.\n\nNotez que si Aivu est actuellement trop petit ou inadapté à la monture (incapacité, mort, etc.), le personnage tentera de monter son familier de classe à la place.",
			itIT: "Se abilitato, un personaggio Azata monterà Aivu al posto del suo animale domestico di classe (se ne possiede uno) quando si usa il tasto di scelta rapida Montaggio automatico e la funzione Montaggio automatico all'ingresso nell'area.\n\n<b>N.B.</b> Questo avrà effetto solo per i personaggi che hanno Aivu e un altro animale domestico cavalcabile contemporaneamente. Dovrebbe funzionare anche per i compagni che prendono Azata tramite ToyBox, ecc. se hanno un secondo animale domestico.\n\nNota che se Aivu è attualmente troppo piccolo o comunque non adatto a essere montato (inabile, morto, ecc.), il personaggio tenterà di montare il suo animale domestico di classe.",
			plPL: "Po włączeniu, postać Azata będzie dosiadać Aivu zamiast swojego klasowego zwierzaka (jeśli go posiada) podczas korzystania ze skrótu klawiszowego AutoMount i automatycznego Mount On Entering Area.\n\n<b>N.B.</b> Będzie to miało wpływ tylko na postacie, które mają Aivu i innego, nadającego się do jazdy zwierzaka jednocześnie. Powinno to również działać dla towarzyszy biorących Azatę przez ToyBox itp., jeśli mają drugiego zwierzaka.\n\nNależy pamiętać, że jeśli Aivu jest obecnie za mały lub w inny sposób nie nadaje się do dosiadania (unieruchomiony, martwy itp.), postać spróbuje dosiąść swojego klasowego zwierzaka.",
			ptBR: "Quando habilitado, um personagem Azata montará em Aivu em vez de seu mascote de classe (se tiver um) ao usar a tecla de atalho Montar Automaticamente e a opção Montar Automaticamente ao Entrar na Área.\n\n<b>OBS.</b> Isso só terá efeito para personagens que tenham Aivu e outro mascote montável simultaneamente. Também deve funcionar para companheiros que pegarem Azata via ToyBox, etc., se tiverem um segundo mascote.\n\nObserve que se Aivu estiver muito pequeno ou impróprio para montar (incapacitado, morto, etc.), o personagem tentará montar em seu mascote de classe.",
			ruRU: "Если эта функция включена, персонаж Azata будет ездить на Aivu вместо своего классового питомца (если он у него есть) при использовании горячей клавиши AutoMount и автоматического Mount On Entering Area.\n\n<b>N.B.</b> Это сработает только для персонажей, у которых одновременно есть Aivu и другой ездовой питомец. Это также должно работать для компаньонов, берущих Azata через ToyBox и т. д., если у них есть второй питомец.\n\nОбратите внимание, что если Aivu в данный момент слишком мал или иным образом не подходит для езды (недееспособен, мертв и т. д.), персонаж попытается вместо этого сесть на своего классового питомца.",
			zhCN: "启用后，Azata 角色在使用“自动骑乘”热键和“进入区域时自动骑乘”功能时，将骑乘 Aivu，而不是其职业宠物（如果有）。\n\n<b>注意</b> 此功能仅对同时拥有 Aivu 和另一只可骑乘宠物的角色生效。如果同伴拥有第二只宠物，并且他们通过玩具箱等方式携带 Azata，此功能也同样有效。\n\n请注意，如果 Aivu 当前太小或因其他原因不适合骑乘（例如丧失行动能力、死亡等），角色将尝试骑乘其职业宠物。"
		);

		public static readonly LocalizedString ToggleConsoleOutputDesc = Utilities.CreateStringAll("dpautomount-consoleoutput-desc",
			enGB: "Enable Combat Log Output",
			deDE: "Kampfprotokollausgabe aktivieren",
			esES: "Habilitar la salida del registro de combate",
			frFR: "Activer la sortie du journal de combat",
			itIT: "Abilita l'output del registro di combattimento",
			plPL: "Włącz wyjście dziennika walki",
			ptBR: "Habilitar saída de registro de combate",
			ruRU: "Включить вывод журнала боя",
			zhCN: "启用战斗日志输出"
		);

		public static readonly LocalizedString ToggleConsoleOutputDescLong = Utilities.CreateStringAll("dpautomount-consoleoutput-desc-long",
			enGB: "Outputs simple notifications of mod actions to the combat log. \n\n<b>N.B.</b> A notification will always be displayed when entering an area that prohibits mounting if the Mount On Entering Area setting is also enabled, regardless of this setting.",
			deDE: "Gibt einfache Benachrichtigungen über Mod-Aktionen an das Kampfprotokoll aus. \n\n<b>Hinweis:</b> Beim Betreten eines Bereichs, in dem das Aufreiten verboten ist, wird immer eine Benachrichtigung angezeigt, wenn die Einstellung „Beim Betreten des Bereichs aufreiten“ ebenfalls aktiviert ist, unabhängig von dieser Einstellung.",
			esES: "Envía notificaciones simples de acciones de mod al registro de combate. \n\n<b>N.B.</b> Siempre se mostrará una notificación al ingresar a un área que prohíbe montar si la configuración Montar al ingresar al área también está habilitada, independientemente de esta configuración.",
			frFR: "Envoie des notifications simples des actions du modérateur dans le journal de combat. \n\n<b>N.B.</b> Une notification sera toujours affichée lors de l'entrée dans une zone interdisant le montage si le paramètre Monter à l'entrée dans la zone est également activé, quel que soit ce paramètre.",
			itIT: "Invia semplici notifiche delle azioni delle mod al registro di combattimento. \n\n<b>N.B.</b> Verrà sempre visualizzata una notifica quando si entra in un'area che proibisce la salita a cavallo se è abilitata anche l'impostazione Sali a cavallo all'ingresso nell'area, indipendentemente da questa impostazione.",
			plPL: "Wysyła proste powiadomienia o akcjach modów do dziennika walki. \n\n<b>UWAGA.</b> Powiadomienie będzie zawsze wyświetlane przy wejściu na obszar, który zabrania dosiadania wierzchowca, jeśli włączone jest również ustawienie Mount On Entering Area, niezależnie od tego ustawienia.",
			ptBR: "Envia notificações simples de ações do mod para o registro de combate. \n\n<b>N.B.</b> Uma notificação sempre será exibida ao entrar em uma área que proíbe a montagem se a configuração Montar ao entrar na área também estiver habilitada, independentemente desta configuração.",
			ruRU: "Выводит простые уведомления о действиях модов в журнал боя. \n\n<b>Примечание.</b> Уведомление всегда будет отображаться при входе в зону, запрещающую езду верхом, если также включена настройка «Монтаж при входе в зону», независимо от этой настройки.",
			zhCN: "将 mod 操作的简单通知输出到战斗日志。\n\n<b>注意</b>如果“进入区域时骑乘”设置也启用，则进入禁止骑乘的区域时将始终显示通知，无论此设置如何。"
		);

		public static readonly LocalizedString ToggleConsoleDebugDesc = Utilities.CreateStringAll("dpautomount-consoledebug-desc",
			enGB: "Enable Additional Debug Output",
			deDE: "Zusätzliche Debug-Ausgabe aktivieren",
			esES: "Habilitar salida de depuración adicional",
			frFR: "Activer la sortie de débogage supplémentaire",
			itIT: "Abilita output di debug aggiuntivo",
			plPL: "Włącz dodatkowe wyjście debugowania",
			ptBR: "Habilitar saída de depuração adicional",
			ruRU: "Включить дополнительный отладочный вывод",
			zhCN: "启用附加调试输出"
		);

		public static readonly LocalizedString ToggleConsoleDebugDescLong = Utilities.CreateStringAll("dpautomount-consoledebug-desc-long",
			enGB: "Adds additional information to failure messages in the combat log as a pop-up/tooltip, and also saves it to the Player.log file. Only intended for troubleshooting purposes, generally not recommended to leave on.\n\n<b>N.B.</b>: Requires the above Combat Log Output setting to be enabled. Due to Mod Menu only reading setting values on the initial opening of the screen, switch tabs or close and reopen the menu after enabling Combat Log Output and saving the settings.",
			deDE: "Fügt Fehlermeldungen im Kampfprotokoll zusätzliche Informationen als Popup/Tooltip hinzu und speichert diese in der Datei Player.log. Diese Option dient ausschließlich der Fehlerbehebung und sollte generell nicht aktiviert bleiben.\n\n<b>Hinweis:</b>: Die oben genannte Einstellung für die Kampfprotokollausgabe muss aktiviert sein. Da das Mod-Menü die Einstellungswerte nur beim ersten Öffnen des Bildschirms liest, wechseln Sie die Registerkarten oder schließen Sie das Menü und öffnen Sie es erneut, nachdem Sie die Kampfprotokollausgabe aktiviert und die Einstellungen gespeichert haben.",
			esES: "Añade información adicional a los mensajes de fallo en el registro de combate como una ventana emergente o información sobre herramientas, y también la guarda en el archivo Player.log. Solo se utiliza para solucionar problemas; generalmente no se recomienda dejarla activada.\n\n<b>Nota:</b> Requiere que la opción Salida del Registro de Combate esté habilitada. Dado que el menú de mods solo lee los valores de configuración al abrir la pantalla, cambia de pestaña o cierra y vuelve a abrir el menú después de habilitar la Salida del Registro de Combate y guardar la configuración.",
			frFR: "Ajoute des informations supplémentaires aux messages d'échec du journal de combat sous forme de fenêtre contextuelle/info-bulle, et les enregistre dans le fichier Player.log. Uniquement destiné au dépannage, il est généralement déconseillé de le laisser activé.\n\n<b>N.B.</b> : Nécessite l'activation du paramètre Sortie du journal de combat ci-dessus. Le menu Mod ne lisant les valeurs des paramètres qu'à l'ouverture initiale de l'écran, changez d'onglet ou fermez puis rouvrez le menu après avoir activé la Sortie du journal de combat et enregistré les paramètres.",
			itIT: "Aggiunge informazioni aggiuntive ai messaggi di errore nel registro di combattimento come pop-up/suggerimento, salvandole anche nel file Player.log. Da utilizzare solo per la risoluzione dei problemi, generalmente non è consigliabile lasciarlo attivo.\n\n<b>N.B.</b>: Richiede l'attivazione dell'impostazione Output del registro di combattimento di cui sopra. Poiché il menu Mod legge i valori delle impostazioni solo all'apertura iniziale della schermata, cambiare scheda o chiudere e riaprire il menu dopo aver attivato Output del registro di combattimento e salvato le impostazioni.",
			plPL: "Dodaje dodatkowe informacje do komunikatów o błędach w dzienniku walki jako wyskakujące okienko/podpowiedź, a także zapisuje je w pliku Player.log. Przeznaczone wyłącznie do celów rozwiązywania problemów, generalnie nie zaleca się pozostawiania włączonego.\n\n<b>UWAGA.</b>: Wymaga włączenia powyższego ustawienia Combat Log Output. Ponieważ Mod Menu odczytuje wartości ustawień tylko przy pierwszym otwarciu ekranu, przełącz zakładki lub zamknij i ponownie otwórz menu po włączeniu Combat Log Output i zapisaniu ustawień.",
			ptBR: "Dodaje dodatkowe informacje do komunikatów o błędach w dzienniku walki jako wyskakujące okienko/podpowiedź, a także zapisuje je w pliku Player.log. Przeznaczone wyłącznie do celów rozwiązywania problemów, generalnie nie zaleca się pozostawiania włączonego.\n\n<b>UWAGA.</b>: Wymaga włączenia powyższego ustawienia Combat Log Output. Ponieważ Mod Menu odczytuje wartości ustawień tylko przy pierwszym otwarciu ekranu, przełącz zakładki lub zamknij i ponownie otwórz menu po włączeniu Combat Log Output i zapisaniu ustawień.",
			ruRU: "Добавляет дополнительную информацию к сообщениям об ошибках в журнале боя в виде всплывающего окна/подсказки, а также сохраняет ее в файле Player.log. Предназначено только для устранения неполадок, обычно не рекомендуется оставлять включенным.\n\n<b>Примечание.</b>: Требует включения вышеуказанной настройки вывода журнала боя. Поскольку меню модов считывает только значения настроек при первом открытии экрана, переключите вкладки или закройте и снова откройте меню после включения вывода журнала боя и сохранения настроек.",
			zhCN: "将附加信息以弹出窗口/工具提示的形式添加到战斗日志中的失败消息中，并将其保存到 Player.log 文件中。仅用于故障排除，通常不建议启用。\n\n<b>注意</b>：需要启用上述“战斗日志输出”设置。由于“模组菜单”仅在屏幕首次打开时读取设置值，请在启用“战斗日志输出”并保存设置后切换标签页或关闭并重新打开菜单。"
		);

		public static readonly LocalizedString ToggleMountHotKeyDesc = Utilities.CreateStringAll("dpautomount-mounthotkey-desc",
			enGB: "Mount",
			deDE: "Reittier",
			esES: "Montar mascota",
			frFR: "Monter un animal de compagnie",
			itIT: "Cavalca animale domestico",
			plPL: "Jedź zwierzakiem",
			ptBR: "Passeio de animal de estimação",
			ruRU: "Ездить на домашнем животном",
			zhCN: "骑乘宠物"
		);

		public static readonly LocalizedString ToggleMountHotKeyDescLong = Utilities.CreateStringAll("dpautomount-mounthotkey-desc-long",
			enGB: "Sets the hotkey for mounting all whitelisted party members.",
			deDE: "Legt den Hotkey zum Einsteigen aller auf der Whitelist stehenden Gruppenmitglieder fest.",
			esES: "Establece la tecla de acceso rápido para montar a todos los miembros del grupo incluidos en la lista blanca.",
			frFR: "Définit le raccourci clavier pour monter tous les membres du groupe sur liste blanche.",
			itIT: "Imposta il tasto di scelta rapida per montare tutti i membri del gruppo nella whitelist.",
			plPL: "Ustawia klawisz skrótu do wsiadania na wszystkich członków drużyny znajdujących się na białej liście.",
			ptBR: "Define a tecla de atalho para montar todos os membros do grupo na lista de permissões.",
			ruRU: "Устанавливает горячую клавишу для монтирования всех членов группы из белого списка.",
			zhCN: "设置所有白名单队员的骑行热键。"
		);

		public static readonly LocalizedString ToggleDismountHotKeyDesc = Utilities.CreateStringAll("dpautomount-dismounthotkey-desc",
			enGB: "Dismount",
			deDE: "Abgang",
			esES: "Desmontar",
			frFR: "Démonter",
			itIT: "Smontare",
			plPL: "Zdemontować",
			ptBR: "Desmontar",
			ruRU: "Спешиться",
			zhCN: "下马"
		);

		public static readonly LocalizedString ToggleDismountHotKeyDescLong = Utilities.CreateStringAll("dpautomount-dismounthotkey-desc-long",
			enGB: "Sets the hotkey for dismounting all whitelisted party members.",
			deDE: "Legt den Hotkey zum Absteigen aller auf der Whitelist stehenden Gruppenmitglieder fest.",
			esES: "Establece la tecla de acceso rápido para desmontar a todos los miembros del grupo incluidos en la lista blanca.",
			frFR: "Définit le raccourci clavier pour démonter tous les membres du groupe sur liste blanche.",
			itIT: "Imposta il tasto di scelta rapida per smontare tutti i membri del gruppo inseriti nella whitelist.",
			plPL: "Ustawia klawisz skrótu do zsiadania ze wszystkich członków drużyny znajdujących się na białej liście.",
			ptBR: "Define a tecla de atalho para desmontar todos os membros do grupo na lista de permissões.",
			ruRU: "Устанавливает горячую клавишу для спешивания всех членов группы из белого списка.",
			zhCN: "设置所有白名单队员下马的热键。"
		);

		public static string WLSlotDesc()
		{
			return LocalizationManager.CurrentPack.Locale switch
			{
				Locale.enGB => "Slot {0}",
				Locale.deDE => "Steckplatz {0}",
				Locale.esES => "Ranura {0}",
				Locale.frFR => "Emplacement {0}",
				Locale.itIT => "Spazio {0}",
				//Locale.plPL => "Miejsce {0}",
				Locale.ptBR => "Slot {0}",
				Locale.ruRU => "Слот {0}",
				Locale.zhCN => "插槽 {0}",
				_ => "Slot {0}"
			};
		}

		public static string WLSlotDescLong()
		{
			return LocalizationManager.CurrentPack.Locale switch
			{
				Locale.enGB => "Enables hotkeyed mount / dismount for the party member in slot {0}. (You can change party order by dragging character portraits).",
				Locale.deDE => "Aktiviert das Auf- und Absteigen per Hotkey für das Gruppenmitglied im Slot {0}. (Sie können die Gruppenreihenfolge ändern, indem Sie die Charakterporträts ziehen.)",
				Locale.esES => "Habilita el acceso rápido a la montura/desmontaje para el miembro del grupo en la ranura {0}. (Puedes cambiar el orden del grupo arrastrando los retratos de los personajes).",
				Locale.frFR => "Active le raccourci clavier pour monter/ descendre pour le membre du groupe dans l'emplacement {0}. (Vous pouvez modifier l'ordre du groupe en faisant glisser les portraits des personnages.)",
				Locale.itIT => "Abilita la salita/discesa con tasti di scelta rapida per il membro del gruppo nello slot {0}. (È possibile modificare l'ordine del gruppo trascinando i ritratti dei personaggi).",
				//Locale.plPL => "Umożliwia skrót klawiszowy dosiadania/zsiadania dla członka drużyny w slocie {0}. (Możesz zmienić kolejność drużyny, przeciągając portrety postaci).",
				Locale.ptBR => "Permite montar/desmontar com atalhos de teclado para o membro do grupo no slot {0}. (Você pode alterar a ordem do grupo arrastando os retratos dos personagens).",
				Locale.ruRU => "Включает горячую клавишу для ездового животного/спешивания для члена группы в слоте {0}. (Вы можете изменить порядок группы, перетаскивая портреты персонажей).",
				Locale.zhCN => "为栏位 {0} 中的队员启用热键上/ 下马功能。（您可以通过拖动角色肖像来更改队伍顺序。）。",
				_ => "Enables hotkeyed mount / dismount for the party member in slot {0}. (You can change party order by dragging character portraits).\n\nNO VALID LOCALE DETECTED"
			};
		}

		public static readonly LocalizedString ToggleAutoMountInCombatHotKeyDesc = Utilities.CreateStringAll("dpautomount-toggleautomountincombat-desc",
			enGB: "Toggle Auto Mount in Combat",
			deDE: "Auto-Reittier im Kampf umschalten",
			esES: "Alternar montura automática en combate",
			frFR: "Activer/désactiver la monture automatique en combat",
			itIT: "Attiva/disattiva monta automatica in combattimento",
			plPL: "Przełącz automatyczne dosiadanie w walce",
			ptBR: "Alternar montaria automática em combate",
			ruRU: "Переключить автоседло в бою",
			zhCN: "切换战斗中自动骑乘"
		);

		public static readonly LocalizedString ToggleAutoMountInCombatHotKeyDescLong = Utilities.CreateStringAll("dpautomount-toggleautomountincombat-desc-long",
			enGB: "Toggle automatic mounting preference for the selected character when combat starts. When enabled, the character will automatically mount their companion at the beginning of combat. When disabled, the character will dismount when combat starts.",
			deDE: "Umschalten der automatischen Reitpräferenz für den ausgewählten Charakter zu Kampfbeginn. Wenn aktiviert, reitet der Charakter automatisch auf seinen Begleiter zu Kampfbeginn auf. Wenn deaktiviert, steigt der Charakter ab, wenn der Kampf beginnt.",
			esES: "Alternar la preferencia de montaje automático para el personaje seleccionado cuando comience el combate. Cuando está habilitado, el personaje montará automáticamente a su compañero al comienzo del combate. Cuando está deshabilitado, el personaje desmontará cuando comience el combate.",
			frFR: "Basculer la préférence de montage automatique pour le personnage sélectionné lorsque le combat commence. Lorsqu'elle est activée, le personnage montera automatiquement sur son compagnon au début du combat. Lorsqu'elle est désactivée, le personnage descendra lorsque le combat commencera.",
			itIT: "Attiva/disattiva la preferenza di montaggio automatico per il personaggio selezionato quando inizia il combattimento. Quando è abilitata, il personaggio monterà automaticamente sul suo compagno all'inizio del combattimento. Quando è disabilitata, il personaggio smonterà quando inizia il combattimento.",
			plPL: "Przełącz preferencję automatycznego dosiadania dla wybranej postaci po rozpoczęciu walki. Po włączeniu postać automatycznie dosiądzie swojego towarzysza na początku walki. Po wyłączeniu postać zejdzie z wierzchowca po rozpoczęciu walki.",
			ptBR: "Alternar preferência de montaria automática para o personagem selecionado quando o combate começa. Quando habilitado, o personagem montará automaticamente em seu companheiro no início do combate. Quando desabilitado, o personagem desmontará quando o combate começar.",
			ruRU: "Переключить предпочтение автоматического седла для выбранного персонажа при начале боя. Когда включено, персонаж автоматически сядет на своего спутника в начале боя. Когда отключено, персонаж слезет, когда начнется бой.",
			zhCN: "为选定角色切换战斗开始时的自动骑乘偏好。启用时，角色将在战斗开始时自动骑乘其同伴。禁用时，角色将在战斗开始时下马。"
		);

		public static readonly LocalizedString ToggleAutoMountOutCombatHotKeyDesc = Utilities.CreateStringAll("dpautomount-toggleautomountoutcombat-desc",
			enGB: "Toggle Auto Mount out of Combat",
			deDE: "Auto-Reittier außerhalb des Kampfes umschalten",
			esES: "Alternar montura automática fuera de combate",
			frFR: "Activer/désactiver la monture automatique hors combat",
			itIT: "Attiva/disattiva monta automatica fuori dal combattimento",
			plPL: "Przełącz automatyczne dosiadanie poza walką",
			ptBR: "Alternar montaria automática fora de combate",
			ruRU: "Переключить автоседло вне боя",
			zhCN: "切换非战斗状态自动骑乘"
		);

		public static readonly LocalizedString ToggleAutoMountOutCombatHotKeyDescLong = Utilities.CreateStringAll("dpautomount-toggleautomountoutcombat-desc-long",
			enGB: "Toggle staying mounted preference for the selected character when leaving combat. When enabled, the character will remain mounted after combat ends. When disabled, the character will automatically dismount when combat ends.",
			deDE: "Umschalten der Reitpräferenz für den ausgewählten Charakter beim Verlassen des Kampfes. Wenn aktiviert, bleibt der Charakter nach Kampfende geritten. Wenn deaktiviert, steigt der Charakter automatisch ab, wenn der Kampf endet.",
			esES: "Alternar la preferencia de permanecer montado para el personaje seleccionado al salir del combate. Cuando está habilitado, el personaje permanecerá montado después de que termine el combate. Cuando está deshabilitado, el personaje desmontará automáticamente cuando termine el combate.",
			frFR: "Basculer la préférence de rester monté pour le personnage sélectionné en quittant le combat. Lorsqu'elle est activée, le personnage restera monté après la fin du combat. Lorsqu'elle est désactivée, le personnage descendra automatiquement lorsque le combat se terminera.",
			itIT: "Attiva/disattiva la preferenza di rimanere in sella per il personaggio selezionato quando esce dal combattimento. Quando è abilitata, il personaggio rimarrà in sella dopo la fine del combattimento. Quando è disabilitata, il personaggio smonterà automaticamente quando finisce il combattimento.",
			plPL: "Przełącz preferencję pozostania na wierzchowcu dla wybranej postaci po wyjściu z walki. Po włączeniu postać pozostanie na wierzchowcu po zakończeniu walki. Po wyłączeniu postać automatycznie zejdzie z wierzchowca po zakończeniu walki.",
			ptBR: "Alternar preferência de permanecer montado para o personagem selecionado ao sair do combate. Quando habilitado, o personagem permanecerá montado após o fim do combate. Quando desabilitado, o personagem desmontará automaticamente quando o combate terminar.",
			ruRU: "Переключить предпочтение оставаться в седле для выбранного персонажа при выходе из боя. Когда включено, персонаж останется в седле после окончания боя. Когда отключено, персонаж автоматически слезет, когда бой закончится.",
			zhCN: "为选定角色切换离开战斗时保持骑乘状态的偏好。启用时，角色将在战斗结束后保持骑乘状态。禁用时，角色将在战斗结束时自动下马。"
		);

		// Blueprint Core Toggle Abilities
		public static readonly LocalizedString AutoMountWhenInCombatAbilityName = Utilities.CreateStringAll("AutoMountWhenInCombat.Ability.Name",
			enGB: "Auto Mount When In Combat",
			deDE: "Auto-Aufsteigen im Kampf",
			esES: "Montar automáticamente cuando está en combate",
			frFR: "Montage automatique en combat",
			itIT: "Montaggio automatico quando in combattimento",
			plPL: "Automatyczne wsiadanie podczas walki",
			ptBR: "Montagem automática quando em combate",
			ruRU: "Автосадка в бою",
			zhCN: "战斗中自动骑乘"
		);

		public static readonly LocalizedString AutoMountWhenInCombatAbilityDescription = Utilities.CreateStringAll("AutoMountWhenInCombat.Ability.Description",
			enGB: "When enabled, this character will automatically mount their animal companion when combat starts.",
			deDE: "Wenn aktiviert, wird dieser Charakter automatisch auf seinem tierischen Begleiter aufsteigen, wenn der Kampf beginnt.",
			esES: "Cuando está habilitado, este personaje montará automáticamente a su compañero animal cuando comience el combate.",
			frFR: "Lorsqu'il est activé, ce personnage montera automatiquement sur son compagnon animal au début du combat.",
			itIT: "Quando abilitato, questo personaggio monterà automaticamente il suo compagno animale quando inizia il combattimento.",
			plPL: "Po włączeniu postać automatycznie wsiądzie na swojego zwierzęcego towarzysza na początku walki.",
			ptBR: "Quando habilitado, este personagem montará automaticamente seu companheiro animal quando o combate começar.",
			ruRU: "При включении этот персонаж автоматически сядет на своего животного компаньона в начале боя.",
			zhCN: "启用时，该角色将在战斗开始时自动骑乘其动物伙伴。"
		);

		public static readonly LocalizedString AutoMountWhenNotInCombatAbilityName = Utilities.CreateStringAll("AutoMountWhenNotInCombat.Ability.Name",
			enGB: "Auto Mount When Not In Combat",
			deDE: "Auto-Aufsteigen außerhalb des Kampfes",
			esES: "Montar automáticamente cuando no está en combate",
			frFR: "Montage automatique hors combat",
			itIT: "Montaggio automatico quando non in combattimento",
			plPL: "Automatyczne wsiadanie poza walką",
			ptBR: "Montagem automática quando não em combate",
			ruRU: "Автосадка вне боя",
			zhCN: "非战斗时自动骑乘"
		);

		public static readonly LocalizedString AutoMountWhenNotInCombatAbilityDescription = Utilities.CreateStringAll("AutoMountWhenNotInCombat.Ability.Description",
			enGB: "When enabled, this character will mount their animal companion after combat ends. When disabled, they will automatically dismount.",
			deDE: "Wenn aktiviert, steigt dieser Charakter nach Kampfende auf seinem tierischen Begleiter auf. Wenn deaktiviert, steigt er automatisch ab.",
			esES: "Cuando está habilitado, este personaje montará a su compañero animal después de que termine el combate. Cuando está deshabilitado, desmontará automáticamente.",
			frFR: "Lorsqu'il est activé, ce personnage montera sur son compagnon animal après la fin du combat. Lorsqu'il est désactivé, il descendra automatiquement.",
			itIT: "Quando abilitato, questo personaggio monterà il suo compagno animale dopo la fine del combattimento. Quando disabilitato, smonterà automaticamente.",
			plPL: "Po włączeniu postać wsiądzie na swojego zwierzęcego towarzysza po zakończeniu walki. Po wyłączeniu automatycznie zejdzie z wierzchowca.",
			ptBR: "Quando habilitado, este personagem montará seu companheiro animal após o fim do combate. Quando desabilitado, desmontará automaticamente.",
			ruRU: "При включении этот персонаж сядет на своего животного компаньона после окончания боя. При отключении он автоматически слезет.",
			zhCN: "启用时，该角色将在战斗结束后骑乘其动物伙伴。禁用时，他们将自动下马。"
		);

		// Buff-specific localized strings for new combat automation features
		public static readonly LocalizedString AutoMountWhenInCombatBuffName = Utilities.CreateStringAll("AutoMountWhenInCombatBuff.Name",
			enGB: "Auto Mount When In Combat (Active)",
			deDE: "Automatisches Aufsteigen im Kampf (Aktiv)",
			esES: "Montar automáticamente en combate (Activo)",
			frFR: "Montage automatique en combat (Actif)",
			itIT: "Montaggio automatico in combattimento (Attivo)",
			plPL: "Automatyczne wsiadanie w walce (Aktywne)",
			ptBR: "Montagem automática em combate (Ativo)",
			ruRU: "Автоседло в бою (Активно)",
			zhCN: "战斗中自动骑乘（活跃）"
		);

		public static readonly LocalizedString AutoMountWhenInCombatBuffDescription = Utilities.CreateStringAll("AutoMountWhenInCombatBuff.Description",
			enGB: "This character will automatically mount their animal companion when combat starts.",
			deDE: "Dieser Charakter wird automatisch auf seinem tierischen Begleiter aufsteigen, wenn der Kampf beginnt.",
			esES: "Este personaje montará automáticamente a su compañero animal cuando comience el combate.",
			frFR: "Ce personnage montera automatiquement sur son compagnon animal au début du combat.",
			itIT: "Questo personaggio monterà automaticamente il suo compagno animale quando inizia il combattimento.",
			plPL: "Ta postać automatycznie wsiądzie na swojego zwierzęcego towarzysza na początku walki.",
			ptBR: "Este personagem montará automaticamente seu companheiro animal quando o combate começar.",
			ruRU: "Этот персонаж автоматически сядет на своего животного компаньона в начале боя.",
			zhCN: "该角色将在战斗开始时自动骑乘其动物伙伴。"
		);

		public static readonly LocalizedString AutoMountWhenNotInCombatBuffName = Utilities.CreateStringAll("AutoMountWhenNotInCombatBuff.Name",
			enGB: "Auto Mount When Not In Combat (Active)",
			deDE: "Nach dem Kampf aufsteigen (Aktiv)",
			esES: "Montar después del combate (Activo)",
			frFR: "Monter après le combat (Actif)",
			itIT: "Montare dopo il combattimento (Attivo)",
			plPL: "Wsiądź po walce (Aktywne)",
			ptBR: "Montar após o combate (Ativo)",
			ruRU: "Сесть после боя (Активно)",
			zhCN: "战斗后骑乘（活跃）"
		);

		public static readonly LocalizedString AutoMountWhenNotInCombatBuffDescription = Utilities.CreateStringAll("AutoMountWhenNotInCombatBuff.Description",
			enGB: "This character will mount their animal companion after combat ends.",
			deDE: "Dieser Charakter wird nach Kampfende auf seinem tierischen Begleiter aufsteigen.",
			esES: "Este personaje montará a su compañero animal después de que termine el combate.",
			frFR: "Ce personnage montera sur son compagnon animal après la fin du combat.",
			itIT: "Questo personaggio monterà il suo compagno animale dopo la fine del combattimento.",
			plPL: "Ta postać wsiądzie na swojego zwierzęcego towarzysza po zakończeniu walki.",
			ptBR: "Este personagem montará seu companheiro animal após o fim do combate.",
			ruRU: "Этот персонаж сядет на своего животного компаньона после окончания боя.",
			zhCN: "该角色将在战斗结束后骑乘其动物伙伴。"
		);
	}
}
