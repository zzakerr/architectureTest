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
        [Header("��� ��������")]
        [SerializeField] private ProjectileType type;

        [Header("�������� �������")]
        [SerializeField] private float velocity;

        [Header("����� ����� �������")]
        [SerializeField] private float lifeTime;

        [Header("���� �������")]
        [SerializeField] private int damage;

        protected virtual void Onhit(Destructible destructible) { }
        protected virtual void Onhit(Collider2D destructible) { }
        protected virtual void OnProjectileLifeEnd(Collider2D col, Vector2 pos) { }

        private Vector2 targetPos;

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

                if (hit.collider.transform.parent.GetComponent<Character>() && hit.collider.transform.parent.GetComponent<Character>().NickName != parrent.NickName)
                {

                    Character dest = hit.collider.transform.parent.GetComponent<Character>();

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

            timer += Time.deltaTime;

            if (timer > lifeTime) OnProjectileLifeEnd(hit.collider, transform.position);

            Move(stepLenght);

        }

        private void Move(float stepLenght)
        {
            Vector2 step = transform.up * stepLenght;

            transform.position += new Vector3(step.x, step.y, 0);
        }

        public void SetParrentShoter(Destructible parrent)
        {
            this.parrent = parrent;
        }
    }
}