﻿using GameEngine.Components;
using Microsoft.Xna.Framework;
using GameEngine.Managers;
using Game.Components;
using Game.Systems;
using System;
using Game.Managers;
using Game.Systems.CoreSystems;
using Microsoft.Xna.Framework.Graphics;
using GameEngine.Systems;

namespace Game
{
    class RPGGame : GameEngine.GameEngine
    {

        GraphicsDevice gd;
        MenuStateManager menuStateManager = MenuStateManager.GetInstance();
        GameStateManager gameStateManager = GameStateManager.GetInstance();
        SystemManager sm = SystemManager.GetInstance();
        SpriteBatch sb;
        ComponentManager cm = ComponentManager.GetInstance();

        private RenderHelper renderHelper;


        protected override void Initialize()
        {
            gd = graphics.GraphicsDevice;
            sb = new SpriteBatch(gd);
            renderHelper = new RenderHelper(gd, sb);
            sm.AddSystems(new object[] {
                new RenderHealthSystem(),
                new RenderInventorySystem(),
                new RenderActionbarSystem(),
                new RenderExperienceSystem(),
                new RenderEnergySystem(),
                new RenderAttackingCollisionBoxSystem(),
                //new ItemIconLoaderSystem(),
                new InventoryLoaderSystem(),
                new SkillLoaderSystem(),
                new SkillManager(),
                new AIMovementSystem(),
                new AIAttackSystem(),
                new EnemySpawnSystem(),
                new AttackSystem(),
                new EnergySystem(),
                new HealthSystem(),
                new InteractSystem(),
                new LevelSystem(),
                new ActionBarSystem(),
                new StatsSystem(),
                new InventorySystem(),
                new PlayerAttackSystem(),
                new PlayerMovementSystem(),
                new SkillSystem(),
                new PlayerSpriteTurnSystem(),
                new KnockbackSystem(),
                new CooldownSystem(),
                new GUISystem(),
                new MenuSystem(),
                new RenderMenuSystem(),
                new InputSystem(),
                new MusicSystem(),
            });

            base.Initialize();

            //Late Update
            sm.AddSystems(new object[] {
                new PlayerArmSystem(),
                new PlayerEquipmentSystem(),
            });
        }

        protected override void LoadContent()
        {
            SystemManager sm = SystemManager.GetInstance();

            ComponentManager cm = ComponentManager.GetInstance();
            EntityFactory factory = new EntityFactory();
            gameStateManager.State = GameState.Menu;
            menuStateManager.State = MenuState.MainMenu;
            
            //################# OUTSIDE MAP FOREST ###############################
            
            // Left oob
            for (int i = 0; i <= 5; i++)
            {
                cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
                {
                    new TextureComponent("forest", RenderLayer.Background1),
                    new PositionComponent(-500, -600 + 600 * i)
                });
            }
            // Right oob
            for (int i = 0; i <= 5; i++)
            {
                cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
                {
                    new TextureComponent("forest", RenderLayer.Background1),
                    new PositionComponent(128 * 40 + 500,  300 +600 * i)
                });
            }
            // top oob
            for (int i = 0; i <= 5; i++)
            {
                cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
                {
                    new TextureComponent("forest", RenderLayer.Background2),
                    new PositionComponent(500 + 1000 * i, -300)
                });
            }
            // bot oob
            for (int i = 0; i <= 5; i++)
            {
                cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
                {
                    new TextureComponent("forest", RenderLayer.Background2),
                    new PositionComponent(500 + 1000 * i, 128 * 14 + 300)
                });
            }

            //########################## TREES ####################################

            //Water tree left
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new TextureComponent("tree1", RenderLayer.Background2),
                    new PositionComponent(0, 128*9)
            });

            //Water tree bot
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new TextureComponent("stone1", RenderLayer.Foreground1),
                    new PositionComponent(128 * 17 - 4, 128 * 14 - 5)
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new TextureComponent("tree1", RenderLayer.Foreground2),
                    new PositionComponent(128 * 17 +50, 128 * 13 + 90)
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new TextureComponent("tree1", RenderLayer.Foreground1),
                    new PositionComponent(128 * 17 + 100, 128 * 13 + 90)
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new TextureComponent("tree1", RenderLayer.Foreground2),
                    new PositionComponent(128 * 17 + 150, 128 * 13 + 90)
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new TextureComponent("tree1", RenderLayer.Foreground1),
                    new PositionComponent(128 * 17 + 200, 128 * 13 + 90)
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new TextureComponent("tree1", RenderLayer.Foreground2),
                    new PositionComponent(128 * 17 + 250, 128 * 13 + 90)
            });

            // Other trees
            for (int i = 0; i < 11; i++)
                factory.AddTree(256, i * 100 + 40);
            for (int i = 0; i < 10; i++)
                factory.AddTree(340, i * 100 + 95);

            for (int i = 0; i < 40; i++)
                factory.AddTree(i * 100 + 400, 300);
            for (int i = 0; i < 40; i++)
                factory.AddTree(i * 100 + 450, 370);


            //################## Map bounds (Collisions) ###############################

            //Left
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new CollisionComponent(40, 128 * 14),
                    new PositionComponent(0, 128 * 7)
            });
            // Top
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new CollisionComponent(128 * 40, 40),
                    new PositionComponent(128 * 20, 0)
            });
            //Right
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new CollisionComponent(40, 128 * 14),
                    new PositionComponent(128 * 40, 128 * 7)
            });
            //Bot
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new CollisionComponent(128 * 40, 40),
                    new PositionComponent(128 * 40 / 2, 128 * 14)
            });
            //Water at bridge - left
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new CollisionComponent(128 * 6 + 10, 20),
                    new PositionComponent(128 * 3 + 20, 128 * 9 - 12)
            });
            //Water at bridge - right
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new CollisionComponent(128 * 12 + 30, 20),
                    new PositionComponent(128 * 13, 128 * 9 - 10)
            });
            //water - other
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                    new CollisionComponent(128 + 164, 128 * 5),
                    new PositionComponent(128 * 18 - 3, 128 * 11 + 54)
            });

            //################### WORDL ITEMS ########################

            // Sign post
            cm.AddEntityWithComponents(factory.CreateSignPost(20, 20, "Be Aware Of The Skeletons Lurking In These Woods! \nIt Might Be A Good Idea To Investigate The Bleeding Stone By The Bridge."));

            //Bleeding stone with loot
            cm.AddEntityWithComponents(factory.CreateNormalSword(128 * 6, 128 * 8));
            cm.AddEntityWithComponents(new IComponent[]
            {
                 new TextureComponent("GameWorld/BloodStone", RenderLayer.Foreground1),
                 new PositionComponent(128*6 - 10, 128*8),
                 new CollisionComponent(45, 30)

            });


            //Player arms!
            cm.AddEntityWithComponents(new IComponent[]
            {
                new PositionComponent(0, 0),
                new AnimationGroupComponent("PlayerAnimation/MEDIUM/PlayerArmsSpritesheetMEDIUM", new Point(4, 8), 150, RenderLayer.Layer3,
                new[] {
                    new Tuple<Point, Point>(new Point(0, 0), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 2), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 3), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 4), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 5), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 6), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 7), new Point(4, 1)),
                }),
                new ArmComponent(),
            });

            cm.AddEntityWithComponents(new IComponent[]
            {
                new PositionComponent(100, 100),
                new AnimationGroupComponent("PlayerAnimation/MEDIUM/PlayerArmsSpritesheetMEDIUM", new Point(4, 8), 150, RenderLayer.Layer3,
                new[] {
                    new Tuple<Point, Point>(new Point(0, 0), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 2), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 3), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 4), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 5), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 6), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 7), new Point(4, 1)),
                }),
                new ArmComponent(),
            });

            //################ ENEMIES #########################

            //Enemy
            cm.AddEntityWithComponents(factory.CreateEnemy(350, 600));
            cm.AddEntityWithComponents(factory.CreateEnemy(310, 600));

            //Enemy
            cm.AddEntityWithComponents(new EnemySpawnComponent(new Point(350, 600), 3, 1000, 100, factory.CreateEnemy(0, 0)));

            //Enemy
            cm.AddEntityWithComponents(new EnemySpawnComponent(new Point(750, 700), 5, 100, 100, factory.CreateEnemy(0, 0)));


            //################## GUI ######################

            // Dialog window
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new GUIComponent(
                GUIType.Misc,
                "UI/DialogWindow",
                new Point(Viewport.TitleSafeArea.Width / 2 - 255, Viewport.TitleSafeArea.Bottom -80),
                RenderLayer.GUI2)
            });
            // P1 hp, ene, xp
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
               new GUIComponent(
               GUIType.Player1,
               "UI/Player1-Hp-Ene-Xp",
               new Point(Viewport.TitleSafeArea.Left,Viewport.TitleSafeArea.Top),
               RenderLayer.GUI2),
            });
            //P2 hp, ene, xp
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
               new GUIComponent(
                   GUIType.Player2,
                   "UI/Player2-Hp-Ene-Xp",
                   new Point(Viewport.TitleSafeArea.Right - 108, Viewport.TitleSafeArea.Top),
                   RenderLayer.GUI2),
            });
            // P1 Ationbar
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
               new GUIComponent(
                   GUIType.Player1,
                   "UI/ActionBar",
                   new Point(Viewport.TitleSafeArea.Left, Viewport.TitleSafeArea.Bottom - 40),
                   RenderLayer.GUI2),
            });
            // P2 Ationbar
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
               new GUIComponent(
                   GUIType.Player2,
                   "UI/ActionBar",
                   new Point(Viewport.TitleSafeArea.Right - 147, Viewport.TitleSafeArea.Bottom - 40),
                   RenderLayer.GUI2),
            });
           

            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new SkillComponent(SkillManager.HeavyAttack, 3, "HeavyAttack"),
                new CooldownComponent(3),
            });

            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new WorldComponent(),
                new SoundComponent(new string[]{"Forest_Theme"}, new string[]{ "Sound/theme" }, new bool[] { true }),
            });

            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new ItemComponent(ItemManager.exampleUseItem, "Staff", ItemType.Weapon),
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new ItemComponent(ItemManager.exampleUseItem, "Sword", ItemType.Weapon),
                new AnimationGroupComponent("PlayerAnimation/MEDIUM/SwordSpritesheetMEDIUM", new Point(4, 4), 150, RenderLayer.Layer3,
                new[] {
                    new Tuple<Point, Point>(new Point(0, 0), new Point(1, 1)),
                    new Tuple<Point, Point>(new Point(0, 1), new Point(1, 1)),
                    new Tuple<Point, Point>(new Point(0, 2), new Point(1, 1)),
                    new Tuple<Point, Point>(new Point(0, 3), new Point(1, 1)),
                    new Tuple<Point, Point>(new Point(0, 0), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 2), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 3), new Point(4, 1)),
                }),
                new SwordComponent(1),
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new ItemComponent(ItemManager.exampleUseItem, "GoldArmorHead", ItemType.Head),
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new ItemComponent(ItemManager.exampleUseItem, "GoldArmorBody", ItemType.Body),

            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new ItemComponent(ItemManager.exampleUseItem, "ChainArmorHead", ItemType.Head),
                new AnimationGroupComponent("PlayerAnimation/MEDIUM/KnightArmorHeadSpritesheetMEDIUM", new Point(4, 4), 150, RenderLayer.Layer2,
                new[] {
                    new Tuple<Point, Point>(new Point(0, 0), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 2), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 3), new Point(4, 1)),
                }),
            });
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new ItemComponent(ItemManager.exampleUseItem, "ChainArmorBody", ItemType.Body),
                new AnimationGroupComponent("PlayerAnimation/MEDIUM/KnightArmorBodySpritesheetMEDIUM", new Point(4, 4), 150, RenderLayer.Layer2,
                new[] {
                    new Tuple<Point, Point>(new Point(0, 0), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 2), new Point(4, 1)),
                    new Tuple<Point, Point>(new Point(0, 3), new Point(4, 1)),
                }),
            });

            

            //######################## Menu Entities ##################################

            // Background
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new MenuBackgroundComponent(
                    "Menu/forest-menu",
                    new Point(0, 0),
                    RenderLayer.Menubackground,
                    true,
                    true
                    )
            });
            // MenuTitle
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new MenuTitleComponent(
                    "Menu/VARJTitle", 
                    RenderLayer.MenuButton, 
                    new Vector2(Viewport.TitleSafeArea.Center.X - 200, Viewport.TitleSafeArea.Top + 50)
                    )
            });
            //Main Menu - 1 Player
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new MenuButtonComponent(
                    MenuButtonType.MainMenuButton,
                    MenuStateManager.MainPlayOnePlayer,
                    "Menu/1PlayerN",
                    "Menu/1PlayerH",
                    new Vector2(Viewport.TitleSafeArea.Center.X - 200, Viewport.TitleSafeArea.Top + 220),
                    RenderLayer.MenuButton
                    )
            });
            // Main Menu - 2 Players
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new MenuButtonComponent(
                    MenuButtonType.MainMenuButton,
                    MenuStateManager.MainPlayTwoPlayer,
                    "Menu/2PlayersN",
                    "Menu/2PlayersH",
                    new Vector2(Viewport.TitleSafeArea.Center.X - 200, Viewport.TitleSafeArea.Top + 340),
                    RenderLayer.MenuButton
                    )
            });
            // Main Menu - Quit game
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
               new MenuButtonComponent(
                   MenuButtonType.MainMenuButton,
                   MenuStateManager.MainQuit,
                   "Menu/QuitN",
                   "Menu/QuitH",
                   new Vector2(Viewport.TitleSafeArea.Center.X - 200, Viewport.TitleSafeArea.Top + 460),
                   RenderLayer.MenuButton
                   )
            }); 
            // Pause Menu //

            // Pause Menu - Resume
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new MenuButtonComponent(
                    MenuButtonType.PauseMainMenuButton,
                    MenuStateManager.PauseResume,
                    "Menu/ResumeN",
                    "Menu/ResumeH",
                    new Vector2(Viewport.TitleSafeArea.Center.X - 200, Viewport.TitleSafeArea.Top + 220),
                    RenderLayer.MenuButton
                    )
            });
            // Pause Menu - Quit
            cm.AddComponentsToEntity(EntityManager.GetEntityId(), new IComponent[]
            {
                new MenuButtonComponent(
                    MenuButtonType.PauseMainMenuButton,
                    MenuStateManager.PauseQuit,
                    "Menu/QuitN",
                    "Menu/QuitH",
                    new Vector2(Viewport.TitleSafeArea.Center.X - 200, Viewport.TitleSafeArea.Top + 340),
                    RenderLayer.MenuButton
                    )
            });


            //player one
            cm.AddEntityWithComponents(factory.CreatePlayerOne(100, 128));

            //sm.GetSystem<ItemIconLoaderSystem>().Load(Content);
            sm.GetSystem<InventoryLoaderSystem>().Load(Content);
            sm.GetSystem<SkillLoaderSystem>().Load(Content);
            sm.GetSystem<RenderEnergySystem>().Load(Content);
            sm.GetSystem<RenderHealthSystem>().Load(Content);
            sm.GetSystem<RenderExperienceSystem>().Load(Content);
            sm.GetSystem<RenderMenuSystem>().Load(Content);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GameStateManager.GetInstance().State == GameState.Menu)
            {
                SystemManager.GetInstance().Update<InputSystem>(gameTime);
                SystemManager.GetInstance().Update<MenuSystem>(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            sb.Begin(SpriteSortMode.FrontToBack);
            
            if (GameStateManager.GetInstance().State == GameState.Menu)
            {
                gd.Clear(Color.White);
                sm.Render<RenderMenuSystem>(renderHelper);
            }
            sb.End();
            base.Draw(gameTime);
        }
    }
}
