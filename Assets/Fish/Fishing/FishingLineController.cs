using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class FishingLineController : MonoBehaviour
{
    // 줄과 상호작용하는 객체들
    public Transform whatTheRopeIsConnectedTo; //줄이 연결된 것
    public Transform whatIsHangingFromTheRope; //줄에 매달린 것

    // 줄을 표시하는 데 사용되는 라인 렌더러
    private LineRenderer lineRenderer;

    // 모든 줄 섹션을 담은 리스트
    public List<Vector3> allRopeSections = new List<Vector3>();

    //줄 길이
    [SerializeField]
    private float ropeLength;
    private float minRopeLength = 0.5f;
    private float maxRopeLength = 1f;
    // 줄이 지탱하는 무게
    private float loadMass = 1f;
    // 더 많은/적은 줄을 추가하는 속도
    float winchSpeed = 10f;

    // whatIsHangingFromTheRope 낚시 바늘의 질량
    [SerializeField]
    private float whatIsHangingFromTheRopeMass;

    // 각 세그먼트의 정보를 담은 리스트와 해당하는 길이와 개수 변수들
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegmentLenght = 0.25f;
    private int segmentCount = 5;
    //낚시줄의 너비
    [SerializeField]
    private float lineWidth;
    [SerializeField] private int startSegmentCount;

    // 줄을 근사화하는 데 사용되는 조인트
    SpringJoint springJoint;



    void Start()
    {
        // SpringJoint 컴포넌트 가져오기
        springJoint = whatTheRopeIsConnectedTo.GetComponent<SpringJoint>();

        // 줄을 표시하는 LineRenderer 컴포넌트 초기화
        lineRenderer = GetComponent<LineRenderer>();

        // 줄의 시작점 설정
        Vector3 ropeStartPoint = Vector3.zero;
        segmentCount = startSegmentCount;
        for (int i = 0; i < segmentCount; i++)
        {
            // 각 세그먼트의 위치 초기화
            ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y += ropeSegmentLenght;
        }

        // 줄 근사화에 필요한 spring 초기화
        UpdateSpring();

        // 줄이 지탱하는 물체에 무게 설정
        whatIsHangingFromTheRope.GetComponent<Rigidbody>().mass = whatIsHangingFromTheRopeMass;
    }



    void Update()
    {
        // LineRenderer를 사용하여 줄 표시
        DisplayRope();
    }

    private void FixedUpdate()
    {
        UpdateWinch();

        Simulation();
    }

    private void InitRope()
    {
        float dist = ropeLength; // 로프의 길이를 나타내는 변수를 설정합니다.
        int tempSegmentCount = (int)(dist * 2f) + startSegmentCount; // 로프 세그먼트의 임시 개수를 계산합니다.

        if (tempSegmentCount > ropeSegments.Count)
        {
            // 만약 계산된 세그먼트 개수가 현재 세그먼트 리스트의 개수보다 많다면 실행됩니다.
            Vector3 ropeStartPoint = ropeSegments[ropeSegments.Count - 1].posNow; // 로프의 시작 지점을 설정합니다.
            segmentCount = tempSegmentCount; // 세그먼트 개수를 임시 개수로 업데이트합니다.
            ropeStartPoint.y += ropeSegmentLenght; // 로프 시작 지점의 y 좌표를 로프 세그먼트의 길이만큼 증가시킵니다.
            ropeSegments.Add(new RopeSegment(ropeStartPoint)); // 새로운 로프 세그먼트를 추가합니다.
        }
        else if (tempSegmentCount < ropeSegments.Count)
        {
            // 만약 계산된 세그먼트 개수가 현재 세그먼트 리스트의 개수보다 적다면 실행됩니다.
            segmentCount = tempSegmentCount; // 세그먼트 개수를 임시 개수로 업데이트합니다.
            ropeSegments.RemoveAt(ropeSegments.Count - 1); // 마지막으로 추가된 로프 세그먼트를 리스트에서 제거합니다.
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

            //Raycast관련 수정된 부분
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
    // 모션 자연스럽게 하기 위한 부분 
    private void ApplyConstraint() // 수정된 부분 이 스크립트로 변경하면됨
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

        //Spring Joint Component의 spring과 damper 부분
        springJoint.spring = kRope * 1.0f;
        springJoint.damper = kRope * 0.05f;

        //Update length of the rope
        springJoint.maxDistance = ropeLength;
    }

    //Add more/less rope
    private void UpdateWinch()
    {
        bool hasChangedRope = false;

        // 스페이스 바를 누를 때 줄의 길이와 segmentCount를 줄임
        if (Input.GetKey(KeyCode.Space) && ropeLength > minRopeLength)
        {
            float decreaseAmount = 5f;
            ropeLength -= decreaseAmount * Time.deltaTime;

            // segmentCount를 줄임
            if (segmentCount > 1)
            {
                segmentCount--;
                hasChangedRope = true;
                Debug.Log("Segment 감소: " + segmentCount);
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