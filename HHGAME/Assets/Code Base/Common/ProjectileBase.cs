using UnityEngine;


public enum ProjectileType
{
    Bullet,
    Rocket,
    Plasma
}

namespace Common
{
    public abstract class ProjectileBase : Entity
    {
        [Header("Тип снарядов")]
        [SerializeField] private ProjectileType type;

        [Header("Скорость снаряда")]
        [SerializeField] private float velocity;

        [Header("Время жизни снаряда")]
        [SerializeField] private float lifeTime;

        [Header("Урон снаряда")]
        [SerializeField] private int damage;

        protected virtual void Onhit(Destructible destructible) { }
        protected virtual void Onhit(Collider2D destructible) { }
        protected virtual void OnProjectileLifeEnd(Collider2D col, Vector2 pos) { }

        protected Vector2 targetPos;

        protected Destructible parrent;

        private float timer;

        [SerializeField]
        protected void FixedUpdate()
        {
            float stepLenght = Time.deltaTime * velocity;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLenght);

            if (hit)
            {
                Onhit(hit.collider);
                if (hit.collider.transform.parent?.GetComponent<Character>() != null)
                {
                    Character dest = hit.collider.transform.parent.GetComponent<Character>();

                    if (dest.NickName != parrent.NickName)
                    {
                        if (dest != null && dest != parrent)
                        {
                            if (dest.CurrentHitPoint > 0)
                            {
                                dest.ApplyDamage(damage);
                            }

                            Onhit(dest);
                        }

                        OnProjectileLifeEnd(hit.collider, hit.point);
                    }
                }  
            }

            timer += Time.deltaTime;

            if (timer > lifeTime) OnProjectileLifeEnd(hit.collider, transform.position);

            Move(stepLenght);

        }

        private void Move(float stepLenght)
        {         
            transform.position = Vector2.MoveTowards(transform.position, targetPos, stepLenght);
            Vector2 Dir = targetPos - (Vector2)transform.position;
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        public void SetParrentShoter(Destructible parrent)
        {
            this.parrent = parrent;
        }
    }
}