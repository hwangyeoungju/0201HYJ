using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class FishingLineController : MonoBehaviour
{
    // �ٰ� ��ȣ�ۿ��ϴ� ��ü��
    public Transform whatTheRopeIsConnectedTo; //���� ����� ��
    public Transform whatIsHangingFromTheRope; //�ٿ� �Ŵ޸� ��

    // ���� ǥ���ϴ� �� ���Ǵ� ���� ������
    private LineRenderer lineRenderer;

    // ��� �� ������ ���� ����Ʈ
    public List<Vector3> allRopeSections = new List<Vector3>();

    //�� ����
    [SerializeField]
    private float ropeLength;
    private float minRopeLength = 0.5f;
    private float maxRopeLength = 1f;
    // ���� �����ϴ� ����
    private float loadMass = 1f;
    // �� ����/���� ���� �߰��ϴ� �ӵ�
    float winchSpeed = 10f;

    // whatIsHangingFromTheRope ���� �ٴ��� ����
    [SerializeField]
    private float whatIsHangingFromTheRopeMass;

    // �� ���׸�Ʈ�� ������ ���� ����Ʈ�� �ش��ϴ� ���̿� ���� ������
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegmentLenght = 0.25f;
    private int segmentCount = 5;
    //�������� �ʺ�
    [SerializeField]
    private float lineWidth;
    [SerializeField] private int startSegmentCount;

    // ���� �ٻ�ȭ�ϴ� �� ���Ǵ� ����Ʈ
    SpringJoint springJoint;



    void Start()
    {
        // SpringJoint ������Ʈ ��������
        springJoint = whatTheRopeIsConnectedTo.GetComponent<SpringJoint>();

        // ���� ǥ���ϴ� LineRenderer ������Ʈ �ʱ�ȭ
        lineRenderer = GetComponent<LineRenderer>();

        // ���� ������ ����
        Vector3 ropeStartPoint = Vector3.zero;
        segmentCount = startSegmentCount;
        for (int i = 0; i < segmentCount; i++)
        {
            // �� ���׸�Ʈ�� ��ġ �ʱ�ȭ
            ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y += ropeSegmentLenght;
        }

        // �� �ٻ�ȭ�� �ʿ��� spring �ʱ�ȭ
        UpdateSpring();

        // ���� �����ϴ� ��ü�� ���� ����
        whatIsHangingFromTheRope.GetComponent<Rigidbody>().mass = whatIsHangingFromTheRopeMass;
    }



    void Update()
    {
        // LineRenderer�� ����Ͽ� �� ǥ��
        DisplayRope();
    }

    private void FixedUpdate()
    {
        UpdateWinch();

        Simulation();
    }

    private void InitRope()
    {
        float dist = ropeLength; // ������ ���̸� ��Ÿ���� ������ �����մϴ�.
        int tempSegmentCount = (int)(dist * 2f) + startSegmentCount; // ���� ���׸�Ʈ�� �ӽ� ������ ����մϴ�.

        if (tempSegmentCount > ropeSegments.Count)
        {
            // ���� ���� ���׸�Ʈ ������ ���� ���׸�Ʈ ����Ʈ�� �������� ���ٸ� ����˴ϴ�.
            Vector3 ropeStartPoint = ropeSegments[ropeSegments.Count - 1].posNow; // ������ ���� ������ �����մϴ�.
            segmentCount = tempSegmentCount; // ���׸�Ʈ ������ �ӽ� ������ ������Ʈ�մϴ�.
            ropeStartPoint.y += ropeSegmentLenght; // ���� ���� ������ y ��ǥ�� ���� ���׸�Ʈ�� ���̸�ŭ ������ŵ�ϴ�.
            ropeSegments.Add(new RopeSegment(ropeStartPoint)); // ���ο� ���� ���׸�Ʈ�� �߰��մϴ�.
        }
        else if (tempSegmentCount < ropeSegments.Count)
        {
            // ���� ���� ���׸�Ʈ ������ ���� ���׸�Ʈ ����Ʈ�� �������� ���ٸ� ����˴ϴ�.
            segmentCount = tempSegmentCount; // ���׸�Ʈ ������ �ӽ� ������ ������Ʈ�մϴ�.
            ropeSegments.RemoveAt(ropeSegments.Count - 1); // ���������� �߰��� ���� ���׸�Ʈ�� ����Ʈ���� �����մϴ�.
        }
    }

    private void Simulation()
    {
        Vector3 forceGravity = new Vector3(0f, -1f, 0f);

        for (int i = 1; i < ropeSegments.Count; i++)
        {
            RopeSegment currentSegment = ropeSegments[i];
            Vector3 velocity = currentSegment.posNow - currentSegment.posOld;
            currentSegment.posOld = currentSegment.posNow;

            //Raycast���� ������ �κ�
            RaycastHit hit;
            if (Physics.Raycast(currentSegment.posNow, -Vector3.up, out hit, 0.1f))
            {
                if (hit.collider != null)
                {
                    velocity = Vector3.zero;
                    forceGravity.y = 0f;
                }
            }

            currentSegment.posNow += velocity;
            currentSegment.posNow += forceGravity * Time.fixedDeltaTime;
            ropeSegments[i] = currentSegment;
        }

        for (int i = 0; i < 20; i++)
        {
            ApplyConstraint();
        }
    }
    /*
    private void ApplyConstraint()
    {
        RopeSegment firstSegment = ropeSegments[0];
        firstSegment.posNow = whatTheRopeIsConnectedTo.position;
        ropeSegments[0] = firstSegment;

        RopeSegment endSegment = ropeSegments[ropeSegments.Count - 1];
        endSegment.posNow = whatIsHangingFromTheRope.position;
        ropeSegments[ropeSegments.Count - 1] = endSegment;

        for (int i=0; i<ropeSegments.Count-1; i++)
        {
            RopeSegment firstSeg = ropeSegments[i];
            RopeSegment secondSeg = ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - ropeSegmentLenght);
            Vector3 changeDir = Vector3.zero;

            if(dist > ropeSegmentLenght)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized.normalized;
            }
            else if (dist < ropeSegmentLenght)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector3 changeAmount = changeDir * error;
            
            if(i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                ropeSegments[i + 1] = secondSeg;
            }
        }

    }*/
    // ��� �ڿ������� �ϱ� ���� �κ� 
    private void ApplyConstraint() // ������ �κ� �� ��ũ��Ʈ�� �����ϸ��
    {
        RopeSegment firstSegment = ropeSegments[0];
        firstSegment.posNow = whatTheRopeIsConnectedTo.position;
        ropeSegments[0] = firstSegment;

        RopeSegment endSegment = ropeSegments[ropeSegments.Count - 1];
        endSegment.posNow = whatIsHangingFromTheRope.position;
        ropeSegments[ropeSegments.Count - 1] = endSegment;

        for (int i = 0; i < ropeSegments.Count - 1; i++)
        {
            RopeSegment firstSeg = ropeSegments[i];
            RopeSegment secondSeg = ropeSegments[i + 1];

            Vector3 direction = secondSeg.posNow - firstSeg.posNow;
            float currentDistance = direction.magnitude;
            float error = Mathf.Abs(currentDistance - ropeSegmentLenght);

            Vector3 changeDir = direction.normalized;
            Vector3 changeAmount = changeDir * error;

            Vector3 moveHalf = changeAmount * 0.5f;

            if (i != 0)
            {
                firstSeg.posNow += moveHalf;
                ropeSegments[i] = firstSeg;
            }

            secondSeg.posNow -= moveHalf;
            ropeSegments[i + 1] = secondSeg;
        }
    }


    //Display the rope with a line renderer
    private void DisplayRope()
    {
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePosition = new Vector3[segmentCount];
        for (int i = 0; i < ropeSegments.Count; i++)
        {
            ropePosition[i] = ropeSegments[i].posNow;
        }
        lineRenderer.positionCount = ropePosition.Length;
        lineRenderer.SetPositions(ropePosition);
    }

    //Update the spring constant and the length of the spring
    private void UpdateSpring()
    {
        //Someone said you could set this to infinity to avoid bounce, but it doesnt work
        //kRope = float.inf

        //
        //The mass of the rope
        //
        //Density of the wire (stainless steel) kg/m3
        float density = 7750f;
        //The radius of the wire
        float radius = 0.02f;

        float volume = Mathf.PI * radius * radius * ropeLength;

        float ropeMass = volume * density;

        //Add what the rope is carrying
        ropeMass += loadMass;


        //
        //The spring constant (has to recalculate if the rope length is changing)
        //
        //The force from the rope F = rope_mass * g, which is how much the top rope segment will carry
        float ropeForce = ropeMass * 9.81f;

        //Use the spring equation to calculate F = k * x should balance this force, 
        //where x is how much the top rope segment should stretch, such as 0.01m

        //Is about 146000
        //float kRope = ropeForce / 0.01f;
        float kRope = 10f;

        //print(ropeMass);

        //Spring Joint Component�� spring�� damper �κ�
        springJoint.spring = kRope * 1.0f;
        springJoint.damper = kRope * 0.05f;

        //Update length of the rope
        springJoint.maxDistance = ropeLength;
    }

    //Add more/less rope
    private void UpdateWinch()
    {
        bool hasChangedRope = false;

        // �����̽� �ٸ� ���� �� ���� ���̿� segmentCount�� ����
        if (Input.GetKey(KeyCode.Space) && ropeLength > minRopeLength)
        {
            float decreaseAmount = 5f;
            ropeLength -= decreaseAmount * Time.deltaTime;

            // segmentCount�� ����
            if (segmentCount > 1)
            {
                segmentCount--;
                hasChangedRope = true;
                Debug.Log("Segment ����: " + segmentCount);
            }

            InitRope();
            whatIsHangingFromTheRope.gameObject.GetComponent<Rigidbody>().WakeUp();
        }

        if (hasChangedRope)
        {
            ropeLength = Mathf.Clamp(ropeLength, minRopeLength, maxRopeLength);
            UpdateSpring();
        }
    }



    public struct RopeSegment
    {
        public Vector3 posNow;
        public Vector3 posOld;

        public RopeSegment(Vector3 pos)
        {
            posNow = pos;
            posOld = pos;
        }
    }
}