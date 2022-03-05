using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheoryScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Unit warrior = new Unit(20, 4);
        warrior.Info();
        Mage sorc = new Mage(10, 2, 8, 10);
        sorc.Info();
        (sorc as Unit).Info();

        warrior.Attack();
        sorc.Attack();
        (sorc as Unit).Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class Unit
    {
        // POLYMORPHISM
        public int hp { get; protected set; }
        public int damage { get; protected set; }
        public Unit(int inputHp, int inputDamage)
        {
            hp = inputHp;
            damage = inputDamage;
        }

        virtual public void Info()
        {
            Debug.Log("hp = " + hp + ", damage = " + damage);
        }

        public void Attack()
        {
            Debug.Log("Deal " + damage + " damage.");
        }
    }

    // INHERITANCE
    class Mage : Unit
    {
        // POLYMORPHISM
        public int magicDamage { get; protected set; }
        public int mp { get; protected set; }
        public int manaCost { get; protected set; }
        public Mage(int inputHp, int inputDamage, int InputMagicDamage, int inputMp)
            : base(inputHp, inputDamage)
        {
            hp = inputHp;
            damage = inputDamage;
            magicDamage = InputMagicDamage;
            mp = inputMp;
        }
        // POLYMORPHISM
        override public void Info()
        {
            Debug.Log("hp = " + hp + ", damage = " + damage + ", magic damage= " + magicDamage + ", mp = " + mp);
        }

        // ABSTRACTION
        new public void Attack()
        {
            Debug.Log("Deal " + magicDamage + " damage, spend one mana point.");
            manaCost = 1;
            mp -= manaCost;
        }
    }
}
